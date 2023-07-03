using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Premedia.Applications.Imaging.Dashboard.Extensions;

public static class ClientConfigurationServiceCollectionExtension
{
    public static void ConfigureClient(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddAutoMapper(typeof(ExternalUserMapping));
        // Add DbContext and UnitOfWork
        services.ConfigurePersistence(configuration);
        services.AddApplicationServices();
        services.AddApplicationServiceValidations();
    }
}