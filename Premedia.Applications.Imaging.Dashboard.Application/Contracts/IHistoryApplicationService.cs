using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Commands;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;

namespace Premedia.Applications.Imaging.Dashboard.Application.Contracts
{
    public interface IHistoryApplicationService
    {
        Task<ActionResult<List<HistoryReadModel>>> GetChangedHistories();
        Task<ActionResult<HistoryReadModel>> GetHistoryById(Guid id);
        Task<ActionResult<List<HistoryReadModel>>> GetAllHistories();
        Task<ActionResult<HistoryReadModel>> CreateHistory(CreateHistoryCommand command);
        Task<ActionResult<HistoryReadModel>> UpdateHistory(Guid id, UpdateHistoryCommand command);
    }
}
