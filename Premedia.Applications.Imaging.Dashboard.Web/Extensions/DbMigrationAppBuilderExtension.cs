using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Premedia.Applications.Imaging.Dashboard.Persistence;

namespace Premedia.Applications.Imaging.Dashboard.Extensions;

public static class DbMigrationAppBuilderExtension
{
    public static void MigrateDatabase(this WebApplication app)
    {
        using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope())
        {
            var context = serviceScope?.ServiceProvider.GetRequiredService<ImagingDashboardDbContext>();
            // Creates the database if it does not exist and applys the migrations
            context?.Database.Migrate();
        }
    }
}