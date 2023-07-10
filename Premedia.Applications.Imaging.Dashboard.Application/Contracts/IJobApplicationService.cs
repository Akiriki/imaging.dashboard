using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
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
    }
}
