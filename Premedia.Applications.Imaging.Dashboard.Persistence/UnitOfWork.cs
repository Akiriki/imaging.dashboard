using Premedia.Applications.Imaging.Dashboard.Persistence.Contracts;

namespace Premedia.Applications.Imaging.Dashboard.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ImagingDashboardDbContext _dbContext;
    private bool _disposed = false;

    public UnitOfWork(ImagingDashboardDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync().ConfigureAwait(false);
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                _dbContext.Dispose();
        _disposed = true;
    }
}