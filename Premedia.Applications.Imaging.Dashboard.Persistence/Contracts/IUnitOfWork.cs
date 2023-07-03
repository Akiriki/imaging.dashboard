namespace Premedia.Applications.Imaging.Dashboard.Persistence.Contracts;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}