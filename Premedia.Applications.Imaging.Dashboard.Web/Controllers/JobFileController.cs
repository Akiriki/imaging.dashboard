using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Contracts;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobFileController : ControllerBase
    {
        private readonly IJobFileApplicationService _jobFileApplicationService;
        public JobFileController(IJobFileApplicationService jobFileApplicationService)
        {
            _jobFileApplicationService = jobFileApplicationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<JobFileReadModel>>> GetNewJobFiles()
        {
            return await _jobFileApplicationService.GetNewJobFiles();
        }

        [HttpGet]
        public async Task<ActionResult<List<JobFileReadModel>>> GetAllJobFiles()
        {
            return await _jobFileApplicationService.GetAllJobFiles();
        }

        [HttpGet]
        public async Task<ActionResult<List<JobFileReadModel>>> GetJobFilesById(Guid id)
        {
            return await _jobFileApplicationService.GetJobFilesById(id);
        }
    }
}
