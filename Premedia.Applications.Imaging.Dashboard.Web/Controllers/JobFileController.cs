using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Contracts;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Controllers
{
    [ApiController]
    public class JobFileController : ControllerBase
    {
        private readonly IJobFileApplicationService _jobFileApplicationService;
        public JobFileController(IJobFileApplicationService jobFileApplicationService)
        {
            _jobFileApplicationService = jobFileApplicationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<JobFileReadModel>>> GetNewJobs()
        {
            return await _jobFileApplicationService.GetNewJobFiles();
        }
    }
}
