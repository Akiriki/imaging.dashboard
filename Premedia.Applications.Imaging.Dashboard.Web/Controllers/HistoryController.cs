using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Contracts;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using System;
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

        [HttpGet]
        public async Task<ActionResult<List<HistoryReadModel>>> GetHistoryById(Guid id)
        {
            return await _historyApplicationService.GetHistoryById(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<HistoryReadModel>>> GetAllHistories()
        {
            return await _historyApplicationService.GetAllHistories();
        }
    }
}
