using Microsoft.EntityFrameworkCore;
using Tililin.Infrastructure.Data.Context;

namespace Tililin.API.Configurations;

public static class WebAppBuilderExtensions
{
    public static void UseMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<TililinDbContext>();
        db.Database.Migrate();
    }
}
