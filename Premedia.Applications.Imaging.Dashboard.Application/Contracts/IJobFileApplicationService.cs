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
    public interface IJobFileApplicationService
    {
        Task<ActionResult<List<JobFileReadModel>>> GetNewJobFiles();
        Task<ActionResult<List<JobFileReadModel>>> GetAllJobFiles();
        Task<ActionResult<JobFileReadModel>> GetJobFileById(Guid id);
        Task<ActionResult<JobFileReadModel>> CreateJobFile(JobFiles jobFileEntity);
        Task<ActionResult<JobFileReadModel>> UpdateJobFile(Guid id, JobFiles jobFileEntity);
    }
}
