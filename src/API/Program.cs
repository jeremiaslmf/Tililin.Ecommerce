using Tililin.API.Configurations;
using Tililin.Application.Common.Hash;
using Tililin.Infrastructure.Data.Context;
using Tililin.Infrastructure.Data.Seed;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.ConnectionStrings.json", optional: true, reloadOnChange: true);

builder.Services.AddApiConfiguration(builder, builder.Configuration);
builder.Services.AddDatabase(builder.Configuration);

var app = builder.Build();

app.UseApiConfiguration();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<TililinDbContext>();
    var hasher = scope.ServiceProvider.GetRequiredService<IAppPasswordHasher>();
    DbInitializer.Seed(db, hasher);
}

app.Run();
