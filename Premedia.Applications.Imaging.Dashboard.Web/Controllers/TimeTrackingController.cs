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
    public class TimeTrackingController : ControllerBase
    {
        private readonly ITimeTrackingApplicationService _timeTrackingApplicationService;
        public TimeTrackingController(ITimeTrackingApplicationService timeTrackingApplicationService)
        {
            _timeTrackingApplicationService = timeTrackingApplicationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TimeTrackingReadModel>>> GetTimeTrackingByEditor(User editor)
        {
            return await _timeTrackingApplicationService.GetTimeTrackingByEditor(editor);
        }

        [HttpGet]
        public async Task<ActionResult<List<TimeTrackingReadModel>>> GetAllTimeTrackings()
        {
            return await _timeTrackingApplicationService.GetAllTimeTrackings();
        }

        [HttpGet]
        public async Task<ActionResult<List<TimeTrackingReadModel>>> GetTimetrackingsById(Guid id)
        {
            return await _timeTrackingApplicationService.GetTimeTrackingById(id);
        }

        [HttpPost]
        public async Task<ActionResult<TimeTrackingReadModel>> CreateTimeTracking(TimeTracking timeTracking)
        {
            return await _timeTrackingApplicationService.CreateTimeTracking(timeTracking);
        }

        [HttpPut]
        public async Task<ActionResult<TimeTrackingReadModel>> UpdateTimeTracking(Guid id, TimeTracking timeTracking)
        {
            return await _timeTrackingApplicationService.UpdateTimeTracking(id, timeTracking);
        }
    }
}
