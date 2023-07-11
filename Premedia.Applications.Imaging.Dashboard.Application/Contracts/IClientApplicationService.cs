using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Application.Contracts
{
    public interface IClientApplicationService
    {
        Task<ActionResult<List<ClientReadModel>>> GetClients();
        Task<ActionResult<List<ClientReadModel>>> GetClientsById(Guid id);
        Task<ActionResult<ClientReadModel>> CreateClient(Client clientEntity);
        Task<ActionResult<ClientReadModel>> UpdateClient(Guid id, Client clientEntity);

    }
}
