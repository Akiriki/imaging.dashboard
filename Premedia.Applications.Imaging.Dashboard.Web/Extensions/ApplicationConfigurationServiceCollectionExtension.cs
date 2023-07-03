using Microsoft.Extensions.DependencyInjection;

namespace Premedia.Applications.Imaging.Dashboard.Extensions;

public static class ApplicationConfigurationServiceCollectionExtension
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        // services
        //     .AddTransient<IProfitcenterApplicationService, ProfitcenterApplicationService>()

    }

    public static void AddApplicationServiceValidations(this IServiceCollection services)
    {
        //services.AddTransient<IExternalUserValidation, ExternalUserValidation>();
    }
}