using Premedia.Applications.Imaging.Dashboard.Core.Entities;

namespace Premedia.Applications.Imaging.Dashboard.Persistence.Contracts;

public interface IUnitOfWork
{
    Task SaveChangesAsync();

    IRepository<Job> JobRepository { get; set; }
    IRepository<JobFiles> JobFileRepository { get; set; }
    IRepository<AdditionalFile> AdditionalFileRepository { get; set; }
    IRepository<Client> ClientRepository { get; set; }
    IRepository<Filepath> FilepathRepository { get; set; }
    IRepository<History> HistoryRepository { get; set; }
    IRepository<User> UserRepository { get; set; }
    IRepository<TimeTracking> TimeTrackingRepository { get; set; }
}