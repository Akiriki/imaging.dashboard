using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Commands;
using Premedia.Applications.Imaging.Dashboard.Application.Contracts;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController:ControllerBase
    {
        private readonly IJobApplicationService _jobApplicationService;
        public JobController(IJobApplicationService jobApplicationService)
        {
            _jobApplicationService=jobApplicationService;
        }

        [HttpGet(nameof(GetNewJobs))]
        public async Task<ActionResult<List<JobReadModel>>> GetNewJobs()
        {
            return await _jobApplicationService.GetNewJobs().ConfigureAwait(false);
        }

        [HttpGet(nameof(GetAllJobs))]
        public async Task<ActionResult<List<JobReadModel>>> GetAllJobs()
        {
            return await _jobApplicationService.GetAllJobs().ConfigureAwait(false);
        }

        [HttpGet(nameof(GetJobById))]
        public async Task<ActionResult<JobReadModel>> GetJobById(Guid id)
        {
            return await _jobApplicationService.GetJobById(id).ConfigureAwait(false);
        }

        [HttpGet(nameof(GetJobsByEditor))]
        public async Task<ActionResult<List<JobReadModel>>> GetJobsByEditor(User editor)
        {
            return await _jobApplicationService.GetJobsByEditor(editor).ConfigureAwait(false);
        }

        [HttpGet(nameof(GetOpenJobsByEditorId))]
        public async Task<ActionResult<List<JobReadModel>>> GetOpenJobsByEditorId(Guid id)
        {
            return await _jobApplicationService.GetOpenJobsByEditorId(id).ConfigureAwait(false);
        }

        [HttpGet(nameof(GetOpenColleagueJobs))]
        public async Task<ActionResult<List<JobReadModel>>> GetOpenColleagueJobs(Guid id)
        {
            return await _jobApplicationService.GetOpenColleagueJobs(id).ConfigureAwait(false);
        }

        [HttpGet(nameof(GetTransferredJobs))]
        public async Task<ActionResult<List<JobReadModel>>> GetTransferredJobs()
        {
            return await _jobApplicationService.GetTransferredJobs().ConfigureAwait(false);
        }

        [HttpGet(nameof(GetDoneJobs))]
        public async Task<ActionResult<List<JobReadModel>>> GetDoneJobs()
        {
            return await _jobApplicationService.GetDoneJobs().ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<ActionResult<JobReadModel>> CreateJob(CreateJobCommand command)
        {
            return await _jobApplicationService.CreateJob(command).ConfigureAwait(false);
        }

        [HttpPut(nameof(UpdateJob))]
        public async Task<ActionResult<JobReadModel>> UpdateJob(UpdateJobCommand command)
        {
            return await _jobApplicationService.UpdateJob(command).ConfigureAwait(false);
        }

        [HttpPut(nameof(ChangeEditor))]
        public async Task<ActionResult<JobReadModel>> ChangeEditor(UpdateJobEditorCommand command)
        {
            return await _jobApplicationService.ChangeEditor(command).ConfigureAwait(false);
        }
    }
}