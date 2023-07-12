using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Contracts;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using Premedia.Applications.Imaging.Dashboard.Application.Services;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;
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

        [HttpGet(nameof(GetAllJobFiles))]
        public async Task<ActionResult<List<JobFileReadModel>>> GetAllJobFiles()
        {
            return await _jobFileApplicationService.GetAllJobFiles();
        }

        [HttpGet(nameof(GetJobFilesById))]
        public async Task<ActionResult<List<JobFileReadModel>>> GetJobFilesById(Guid id)
        {
            return await _jobFileApplicationService.GetJobFilesById(id);
        }

        [HttpPost]
        public async Task<ActionResult<JobFileReadModel>> CreateJobFile(JobFiles jobFile)
        {
            return await _jobFileApplicationService.CreateJobFile(jobFile);
        }

        [HttpPut]
        public async Task<ActionResult<JobFileReadModel>> UpdateJobFile(Guid id, JobFiles jobFile)
        {
            return await _jobFileApplicationService.UpdateJobFile(id, jobFile);
        }
    }
}
