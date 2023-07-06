using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Contracts;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Controllers
{
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientApplicationService _clientApplicationService;
        public ClientController(IClientApplicationService clientApplicationService)
        {
            _clientApplicationService = clientApplicationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientReadModel>>> GetNewClients()
        {
            return await _clientApplicationService.GetNewClients();
        }
    }
}