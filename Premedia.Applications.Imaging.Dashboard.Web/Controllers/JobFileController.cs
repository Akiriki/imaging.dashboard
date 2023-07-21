using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Commands;
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

        [HttpGet(nameof(GetNewJobFiles))]
        public async Task<ActionResult<List<JobFileReadModel>>> GetNewJobFiles()
        {
            return await _jobFileApplicationService.GetNewJobFiles().ConfigureAwait(false);
        }

        [HttpGet(nameof(GetAllJobFiles))]
        public async Task<ActionResult<List<JobFileReadModel>>> GetAllJobFiles()
        {
            return await _jobFileApplicationService.GetAllJobFiles().ConfigureAwait(false);
        }

        [HttpGet(nameof(GetJobFilesById))]
        public async Task<ActionResult<JobFileReadModel>> GetJobFilesById(Guid id)
        {
            return await _jobFileApplicationService.GetJobFileById(id).ConfigureAwait(false);
        }

        [HttpGet(nameof(GetJobFilesByJobId))]
        public async Task<ActionResult<List<JobFileReadModel>>> GetJobFilesByJobId(Guid id)
        {
            return await _jobFileApplicationService.GetJobFilesByJobId(id).ConfigureAwait(false);
        }

        [HttpGet(nameof(GetTransferredJobFiles))]
        public async Task<ActionResult<List<JobFileReadModel>>> GetTransferredJobFiles()
        {
            return await _jobFileApplicationService.GetTransferredJobFiles().ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<ActionResult<JobFileReadModel>> CreateJobFile(CreateJobFileCommand command)
        {
            return await _jobFileApplicationService.CreateJobFile(command).ConfigureAwait(false);
        }

        [HttpPut]
        public async Task<ActionResult<JobFileReadModel>> UpdateJobFile(UpdateJobFileCommand command)
        {
            return await _jobFileApplicationService.UpdateJobFile(command).ConfigureAwait(false);
        }
    }
}