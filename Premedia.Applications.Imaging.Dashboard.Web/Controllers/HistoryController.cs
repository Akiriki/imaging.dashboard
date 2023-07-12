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

        [HttpGet(nameof(GetHistoryById))]
        public async Task<ActionResult<List<HistoryReadModel>>> GetHistoryById(Guid id)
        {
            return await _historyApplicationService.GetHistoryById(id);
        }

        [HttpGet(nameof(GetAllHistories))]
        public async Task<ActionResult<List<HistoryReadModel>>> GetAllHistories()
        {
            return await _historyApplicationService.GetAllHistories();
        }
        [HttpPost]
        public async Task<ActionResult<HistoryReadModel>> CreateHistory(History history)
        {
            return await _historyApplicationService.CreateHistory(history);
        }

        [HttpPut]
        public async Task<ActionResult<HistoryReadModel>> UpdateHistory(Guid id, History history)
        {
            return await _historyApplicationService.UpdateHistory(id, history);
        }
    }
}
