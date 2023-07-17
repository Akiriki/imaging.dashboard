using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace Premedia.Applications.Imaging.Dashboard.Extensions;

public static class AddSwaggerServiceCollectionExtensions
{
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddOpenApiDocument((options, serviceProvider) =>
        {
            options.DocumentName = "ImagingDashboard";
            options.Version = "1.0";
            // This part adds correct FluentValidation for swagger scheme
            options.AllowReferencesWithProperties = true;
            options.FlattenInheritanceHierarchy = true;

            options.PostProcess = document =>
            {
                document.Info.Version = "v1";
                document.Info.Title = "Imaging Dashboard Api";
                document.Info.Description = "Imaging Dashboard Api";
            };

            // options.OperationProcessors.Add(
            //     new OperationSecurityScopeProcessor(ConstantStrings.AuthTypes.CustomAuthScheme));
            // options.AddSecurity(ConstantStrings.AuthTypes.CustomAuthScheme, Enumerable.Empty<string>(),
            //     new OpenApiSecurityScheme()
            //     {
            //         Type = OpenApiSecuritySchemeType.ApiKey,
            //         Name = "Authorization",
            //         In = OpenApiSecurityApiKeyLocation.Header,
            //         Description = "Access Token: " + ConstantStrings.AuthTypes.CustomAuthScheme + " {token}",
            //         Scheme = ConstantStrings.AuthTypes.CustomAuthScheme
            //     }
            // );
        });
    }
}