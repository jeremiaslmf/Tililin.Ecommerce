using Microsoft.AspNetCore.Builder;
using Tililin.Application.Middleware;

namespace Tililin.API.Configurations;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();

        var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseCors("Default");
        app.UseAuthorization();
        app.UseAuthentication();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        return app;
    }
}
