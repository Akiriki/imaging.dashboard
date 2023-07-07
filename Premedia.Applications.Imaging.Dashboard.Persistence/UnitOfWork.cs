using Microsoft.EntityFrameworkCore;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;
using Premedia.Applications.Imaging.Dashboard.Persistence.Contracts;
using Premedia.Applications.Imaging.Dashboard.Persistence.Repositories;
namespace Premedia.Applications.Imaging.Dashboard.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ImagingDashboardDbContext _dbContext;
    private bool _disposed = false;
    public IRepository<Job> JobRepository { get; set; }
    public IRepository<JobFiles> JobFileRepository { get; set; }
    public IRepository<AdditionalFile> AdditionalFileRepository { get; set; }
    public IRepository<Client> ClientRepository { get; set; }
    public IRepository<FilePath> FilePathRepository { get; set; }
    public IRepository<History> HistoryRepository{ get; set; }
    public IRepository<User> UserRepository { get; set; }
    public IRepository<TimeTracking> TimeTrackingRepository { get; set; }

    public UnitOfWork(ImagingDashboardDbContext dbContext)
    {
        _dbContext = dbContext;
        JobRepository = new EntityObjectRepository<Job>(_dbContext);
        JobFileRepository=new EntityObjectRepository<JobFiles>(_dbContext);
        AdditionalFileRepository=new EntityObjectRepository<AdditionalFile>(_dbContext);
        ClientRepository=new EntityObjectRepository<Client>(_dbContext);
        FilePathRepository=new EntityObjectRepository<FilePath>(_dbContext);
        HistoryRepository=new EntityObjectRepository<History>(_dbContext);
        UserRepository=new EntityObjectRepository<User>(_dbContext);
        TimeTrackingRepository=new EntityObjectRepository<TimeTracking>(_dbContext);

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