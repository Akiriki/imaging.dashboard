using Microsoft.AspNetCore.Hosting;

namespace Premedia.Applications.Imaging.Dashboard.Extensions;

public static class HostingEnvironmentExtensions
{
    public static bool IsLocal(this IWebHostEnvironment webHostEnvironment)
    {
        return (webHostEnvironment.EnvironmentName == "Local");
    }
}
