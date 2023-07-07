using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Contracts;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryApplicationService _historyApplicationService;
        public HistoryController(IHistoryApplicationService historyApplicationService)
        {
            _historyApplicationService = historyApplicationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<HistoryReadModel>>> GetChangedHistory()
        {
            return await _historyApplicationService.GetChangedHistory();
        }
    }
}
