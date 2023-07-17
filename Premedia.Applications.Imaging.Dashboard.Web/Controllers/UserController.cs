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
            return await _userApplicationService.GetAllUsers();
        }

        [HttpGet(nameof(GetUserById))]
        public async Task<ActionResult<UserReadModel>> GetUserById(Guid id)
        {
            return await _userApplicationService.GetUserById(id);
        }

        [HttpPost]
        public async Task<ActionResult<UserReadModel>> CreateUser(CreateUserCommand command)
        {
            return await _userApplicationService.CreateUser(command);
        }

        [HttpPut]
        public async Task<ActionResult<UserReadModel>> UpdateUser(Guid id, UpdateUserCommand command)
        {
            return await _userApplicationService.UpdateUser(id, command);
        }
    }
}
