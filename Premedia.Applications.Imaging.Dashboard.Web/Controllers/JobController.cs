﻿using Microsoft.AspNetCore.Mvc;
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
            return await _jobApplicationService.GetNewJobs();
        }

        [HttpGet(nameof(GetAllJobs))]
        public async Task<ActionResult<List<JobReadModel>>> GetAllJobs()
        {
            return await _jobApplicationService.GetAllJobs();
        }

        [HttpGet(nameof(GetJobById))]
        public async Task<ActionResult<JobReadModel>> GetJobById(Guid id)
        {
            return await _jobApplicationService.GetJobById(id);
        }

        [HttpGet(nameof(GetJobsByEditor))]
        public async Task<ActionResult<List<JobReadModel>>> GetJobsByEditor(User editor)
        {
            return await _jobApplicationService.GetJobsByEditor(editor);
        }

        [HttpPost]
        public async Task<ActionResult<JobReadModel>> CreateJob(Job job)
        {
            return await _jobApplicationService.CreateJob(job);
        }

        [HttpPut]
        public async Task<ActionResult<JobReadModel>> UpdateJob(Guid id, Job job)
        {
            return await _jobApplicationService.UpdateJob(id, job);
        }

        [HttpPut(nameof(ChangeEditor))]
        public async Task<ActionResult<JobReadModel>> ChangeEditor(Guid id, User editor)
        {
            return await _jobApplicationService.ChangeEditor(id, editor);
        }
    }
}
