using FluentValidation;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Tililin.Application;
using Tililin.Application.Common.Behaviors;
using Tililin.Application.Common.Hash;
using Tililin.Application.Common.Jwt;
using Tililin.Application.Common.Services;
using Tililin.Domain.Constants;
using Tililin.Domain.Repositories;
using Tililin.Infrastructure.Hash;
using Tililin.Infrastructure.Jwt;
using Tililin.Infrastructure.UnitOfWork;

namespace Tililin.API.Configurations;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiConfiguration(this IServiceCollection services, WebApplicationBuilder builder, IConfiguration configuration)
    {
        // Controllers
        services.AddControllers();

        // Swagger (OpenAPI)
        services.AddEndpointsApiExplorer();
        ConfigureSwagger(services);

        // MediatR
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly));

        // FluentValidation
        services.AddValidatorsFromAssembly(typeof(ApplicationAssemblyMarker).Assembly);

        // Pipeline: validação automática antes do handler
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        // HttpContext
        services.AddHttpContextAccessor();

        // User Context
        services.AddScoped<IUserContext, UserContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        //Login Authentication
        ConfigureAuthentication(builder);

        // CORS
        ConfigureCORS(services, builder);

        return services;
    }

    private static void ConfigureSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = DomainConstants.API_NAME, Version = "v1" });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header usando o esquema Bearer.",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });
        });
    }

    private static void ConfigureCORS(IServiceCollection services, WebApplicationBuilder builder)
    {
        string[] allowedOrigins;
        var environment = builder.Environment;
        if (environment.IsDevelopment())
            allowedOrigins = builder.Configuration.GetSection("CorsDev:AllowedOrigins").Get<string[]>() ?? [];
        else
            allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [];

        services.AddCors(options =>
        {
            options.AddPolicy("Default", policy =>
            {
                policy.WithOrigins(allowedOrigins ?? [])
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials();
            });
        });
    }

    private static void ConfigureAuthentication(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAppPasswordHasher, AppPasswordHasher>();
        builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        var jwtSettings = builder.Configuration.GetSection("JwtSettings");
        var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]!);

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });
    }
}
