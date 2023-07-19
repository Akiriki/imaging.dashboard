using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Commands;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;

namespace Premedia.Applications.Imaging.Dashboard.Application.Contracts
{
    public interface IJobFileApplicationService
    {
        Task<ActionResult<List<JobFileReadModel>>> GetNewJobFiles();
        Task<ActionResult<List<JobFileReadModel>>> GetAllJobFiles();
        Task<ActionResult<JobFileReadModel>> GetJobFileById(Guid id);
        Task<ActionResult<List<JobFileReadModel>>> GetTransferredJobFiles()
        Task<ActionResult<JobFileReadModel>> CreateJobFile(CreateJobFileCommand command);
        Task<ActionResult<JobFileReadModel>> UpdateJobFile(UpdateJobFileCommand command);
    }
}