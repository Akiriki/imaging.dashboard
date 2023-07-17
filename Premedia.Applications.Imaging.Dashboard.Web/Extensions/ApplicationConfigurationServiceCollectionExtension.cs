using Microsoft.Extensions.DependencyInjection;
using Premedia.Applications.Imaging.Dashboard.Application.Contracts;
using Premedia.Applications.Imaging.Dashboard.Application.Services;

namespace Premedia.Applications.Imaging.Dashboard.Extensions;

public static class ApplicationConfigurationServiceCollectionExtension
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        // services
        //     .AddTransient<IProfitcenterApplicationService, ProfitcenterApplicationService>()

        services.AddTransient<IJobFileApplicationService, JobFileApplicationService>();
        services.AddTransient<IJobApplicationService, JobApplicationService>();
        services.AddTransient<IAdditionalFileApplicationService, AdditionalFileApplicationService>();
        services.AddTransient<IClientApplicationService, ClientApplicationService>();
        services.AddTransient<IHistoryApplicationService, HistoryApplicationService>();
        services.AddTransient<ITimeTrackingApplicationService, TimeTrackingApplicationService>();
        services.AddTransient<IUserApplicationService, UserApplicationService>();


    }

    public static void AddApplicationServiceValidations(this IServiceCollection services)
    {
        //services.AddTransient<IExternalUserValidation, ExternalUserValidation>()
    }
}