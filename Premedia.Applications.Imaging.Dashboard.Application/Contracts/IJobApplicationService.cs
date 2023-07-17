using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Commands;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;

namespace Premedia.Applications.Imaging.Dashboard.Application.Contracts
{
    public interface IJobApplicationService
    {
        Task<ActionResult<List<JobReadModel>>> GetNewJobs();
        Task<ActionResult<List<JobReadModel>>> GetAllJobs();
        Task<ActionResult<JobReadModel>> GetJobById(Guid id);
        Task<ActionResult<List<JobReadModel>>> GetJobsByEditor(User editor);
        Task<ActionResult<JobReadModel>> CreateJob(CreateJobCommand jobEntity);
        Task<ActionResult<JobReadModel>> UpdateJob(Guid id, UpdateJobCommand command);
        Task<ActionResult<JobReadModel>> ChangeEditor(Guid id, UpdateJobEditorCommand command);

    }
}
