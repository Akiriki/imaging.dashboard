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
    public class ClientController : ControllerBase
    {
        private readonly IClientApplicationService _clientApplicationService;
        public ClientController(IClientApplicationService clientApplicationService)
        {
            _clientApplicationService = clientApplicationService;
        }

        [HttpGet(nameof(GetAllClients))]
        public async Task<ActionResult<List<ClientReadModel>>> GetAllClients()
        {
            return await _clientApplicationService.GetAllClients().ConfigureAwait(false);
        }

        [HttpGet(nameof(GetClientById))]
        public async Task<ActionResult<ClientReadModel>> GetClientById(Guid id)
        {
            return await _clientApplicationService.GetClientById(id).ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<ActionResult<ClientReadModel>> CreateClient(CreateClientCommand command)
        {
            await _clientApplicationService.CreateClient(command).ConfigureAwait(false);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<ClientReadModel>> UpdateClient(Guid id, UpdateClientCommand command)
        {
            await _clientApplicationService.UpdateClient(id, command).ConfigureAwait(false);
            return Ok();
        }
    }
}