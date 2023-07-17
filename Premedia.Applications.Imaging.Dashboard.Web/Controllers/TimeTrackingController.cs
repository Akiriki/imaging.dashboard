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
    public class TimeTrackingController : ControllerBase
    {
        private readonly ITimeTrackingApplicationService _timeTrackingApplicationService;
        public TimeTrackingController(ITimeTrackingApplicationService timeTrackingApplicationService)
        {
            _timeTrackingApplicationService = timeTrackingApplicationService;
        }

        [HttpGet(nameof(GetTimeTrackingByEditor))]
        public async Task<ActionResult<List<TimeTrackingReadModel>>> GetTimeTrackingByEditor(User editor)
        {
            return await _timeTrackingApplicationService.GetTimeTrackingByEditor(editor);
        }

        [HttpGet(nameof(GetAllTimeTrackings))]
        public async Task<ActionResult<List<TimeTrackingReadModel>>> GetAllTimeTrackings()
        {
            return await _timeTrackingApplicationService.GetAllTimeTrackings();
        }

        [HttpGet(nameof(GetTimeTrackingById))]
        public async Task<ActionResult<TimeTrackingReadModel>> GetTimeTrackingById(Guid id)
        {
            return await _timeTrackingApplicationService.GetTimeTrackingById(id);
        }

        [HttpPost]
        public async Task<ActionResult<TimeTrackingReadModel>> CreateTimeTracking(CreateTimeTrackingCommand command)
        {
            return await _timeTrackingApplicationService.CreateTimeTracking(command);
        }

        [HttpPut]
        public async Task<ActionResult<TimeTrackingReadModel>> UpdateTimeTracking(Guid id, UpdateTimeTrackingCommand command)
        {
            return await _timeTrackingApplicationService.UpdateTimeTracking(id, command);
        }
    }
}
