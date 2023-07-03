using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Premedia.Applications.Imaging.Dashboard.Persistence;
using Premedia.Applications.Imaging.Dashboard.Persistence.Contracts;

namespace Premedia.Applications.Imaging.Dashboard.Extensions;

public static class PersitenceConfigurationServiceCollectionExtension
{
    public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ImagingDashboardDbContext>(opts =>
        {
            opts.UseSqlServer(configuration.GetConnectionString("DbConnection"))
                .EnableSensitiveDataLogging();
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}