using Microsoft.EntityFrameworkCore;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;
using Premedia.Applications.Imaging.Dashboard.Persistence.EntityConfigurations;

namespace Premedia.Applications.Imaging.Dashboard.Persistence;

public class ImagingDashboardDbContext : DbContext
{
    public ImagingDashboardDbContext(DbContextOptions<ImagingDashboardDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Automatically adding all Configurations within this assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityObjectConfiguration).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        SaveEntityChanges();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        SaveEntityChanges();
        return base.SaveChanges();
    }

    private void SaveEntityChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is EntityObject && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            if (entityEntry.State == EntityState.Added)
            {
                ((EntityObject)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
            }
        }
    }
}