using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Commands;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;

namespace Premedia.Applications.Imaging.Dashboard.Application.Contracts
{
    public interface IUserApplicationService
    {
        Task<ActionResult<List<UserReadModel>>> GetAllUsers();
        Task<ActionResult<UserReadModel>> GetUserById(Guid id);
        Task<ActionResult<UserReadModel>> CreateUser(CreateUserCommand command);
        Task<ActionResult<UserReadModel>> UpdateUser(Guid id, UpdateUserCommand command);
    }
}
