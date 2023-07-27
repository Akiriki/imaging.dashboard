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
    public class ActivityController : ControllerBase
    {
        private readonly IActivityApplicationService _activityApplicationService;
        public ActivityController(IActivityApplicationService activityApplicationService)
        {
            _activityApplicationService = activityApplicationService;
        }

        [HttpGet(nameof(GetActivityById))]
        public async Task<ActionResult<ActivityReadModel>> GetActivityById(Guid id)
        {
            return await _activityApplicationService.GetActivityById(id).ConfigureAwait(false);
        }

        [HttpGet(nameof(GetAllActivities))]
        public async Task<ActionResult<List<ActivityReadModel>>> GetAllActivities()
        {
            return await _activityApplicationService.GetAllActivities().ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<ActionResult<ActivityReadModel>> CreateActivity(CreateActivityCommand command)
        {
            return await _activityApplicationService.CreateActivity(command).ConfigureAwait(false);
        }

        [HttpPut]
        public async Task<ActionResult<ActivityReadModel>> UpdateActivity(UpdateActivityCommand command)
        {
            return await _activityApplicationService.UpdateActivity(command).ConfigureAwait(false);
        }
    }
}