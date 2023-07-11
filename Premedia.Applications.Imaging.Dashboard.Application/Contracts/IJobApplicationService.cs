using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Application.Contracts
{
    public interface IJobApplicationService
    {
        Task<ActionResult<List<JobReadModel>>> GetNewJobs();
        Task<ActionResult<List<JobReadModel>>> GetAllJobs();
        Task<ActionResult<List<JobReadModel>>> GetJobsById(Guid id);
        Task<ActionResult<List<JobReadModel>>> GetJobsByEditor(User editor);
        Task<ActionResult<JobReadModel>> CreateJob(Job jobEntity);
        Task<ActionResult<JobReadModel>> UpdateJob(Guid id, Job jobEntity);

    }
}
