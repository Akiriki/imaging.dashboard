using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Commands;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;

namespace Premedia.Applications.Imaging.Dashboard.Application.Contracts
{
    public interface IClientApplicationService
    {
        Task<ActionResult<List<ClientReadModel>>> GetAllClients();
        Task<ActionResult<ClientReadModel>> GetClientById(Guid id);
        Task<ActionResult<ClientReadModel>> CreateClient(CreateClientCommand command);
        Task<ActionResult<ClientReadModel>> UpdateClient(Guid id, UpdateClientCommand command);

    }
}
