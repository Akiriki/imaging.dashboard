using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Commands;
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
            return await _clientApplicationService.GetAllClients();
        }

        [HttpGet(nameof(GetClientById))]
        public async Task<ActionResult<ClientReadModel>> GetClientById(Guid id)
        {
            return await _clientApplicationService.GetClientById(id);
        }

        [HttpPost]
        public async Task<ActionResult<ClientReadModel>> CreateClient(CreateClientCommand command)
        {
            return await _clientApplicationService.CreateClient(command);
        }

        [HttpPut]
        public async Task<ActionResult<ClientReadModel>> UpdateClient(Guid id, UpdateClientCommand command)
        {
            return await _clientApplicationService.UpdateClient(id, command);
        }
    }
}