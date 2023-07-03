using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Premedia.Applications.Imaging.Dashboard.Persistence;

public class ImagingDashboardDbContextFactory : DesignTimeDbContextFactoryBase<ImagingDashboardDbContext>
{
    public ImagingDashboardDbContextFactory() : base("DbConnection",
        typeof(ImagingDashboardDbContextFactory).GetTypeInfo().Assembly.GetName().Name ??
        "Premedia.Lutz.ProspektArchiv.ProspektArchivDbContext")
    {
    }

    protected override ImagingDashboardDbContext CreateNewInstance(DbContextOptions<ImagingDashboardDbContext> options)
    {
        return new ImagingDashboardDbContext(options);
    }
}