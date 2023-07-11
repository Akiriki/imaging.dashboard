﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<ActionResult<List<ClientReadModel>>> GetClients()
        {
            return await _clientApplicationService.GetClients();
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientReadModel>>> GetClientsById(Guid id)
        {
            return await _clientApplicationService.GetClientsById(id);
        }

        [HttpPost]
        public async Task<ActionResult<ClientReadModel>> CreateClient(Client client)
        {
            return await _clientApplicationService.CreateClient(client);
        }

        [HttpPut]
        public async Task<ActionResult<ClientReadModel>> UpdateClient(Guid id, Client client)
        {
            return await _clientApplicationService.UpdateClient(id, client);
        }
    }
}