using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Commands;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;

namespace Premedia.Applications.Imaging.Dashboard.Application.Contracts
{
    public interface ITimeTrackingApplicationService
    {
        Task<ActionResult<List<TimeTrackingReadModel>>> GetTimeTrackingByEditor(User editor);
        Task<ActionResult<TimeTrackingReadModel>> GetTimeTrackingById(Guid id);
        Task<ActionResult<List<TimeTrackingReadModel>>> GetAllTimeTrackings();
        Task<ActionResult<TimeTrackingReadModel>> CreateTimeTracking(CreateTimeTrackingCommand command);
        Task<ActionResult<TimeTrackingReadModel>> UpdateTimeTracking(Guid id, UpdateTimeTrackingCommand command);
    }
}
