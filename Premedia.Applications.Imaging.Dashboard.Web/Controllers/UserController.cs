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
    public class UserController : ControllerBase
    {
        private readonly IUserApplicationService _userApplicationService;
        public UserController(IUserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }

        [HttpGet(nameof(GetAllUsers))]
        public async Task<ActionResult<List<UserReadModel>>> GetAllUsers()
        {
            return await _userApplicationService.GetAllUsers().ConfigureAwait(false);
        }

        [HttpGet(nameof(GetUserById))]
        public async Task<ActionResult<UserReadModel>> GetUserById(Guid id)
        {
            return await _userApplicationService.GetUserById(id).ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<ActionResult<UserReadModel>> CreateUser(CreateUserCommand command)
        {
            return await _userApplicationService.CreateUser(command).ConfigureAwait(false);
        }

        [HttpPut]
        public async Task<ActionResult<UserReadModel>> UpdateUser(UpdateUserCommand command)
        {
            return await _userApplicationService.UpdateUser(command).ConfigureAwait(false);
        }
    }
}