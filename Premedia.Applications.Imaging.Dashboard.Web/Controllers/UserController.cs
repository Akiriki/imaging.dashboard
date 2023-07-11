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
    public class UserController : ControllerBase
    {
        private readonly IUserApplicationService _userApplicationService;
        public UserController(IUserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserReadModel>>> GetUser()
        {
            return await _userApplicationService.GetUser();
        }

        [HttpGet]
        public async Task<ActionResult<List<UserReadModel>>> GetUserById(Guid id)
        {
            return await _userApplicationService.GetUserById(id);
        }

        [HttpPost]
        public async Task<ActionResult<UserReadModel>> CreateUser(User user)
        {
            return await _userApplicationService.CreateUser(user);
        }

        [HttpPut]
        public async Task<ActionResult<UserReadModel>> UpdateUser(Guid id, User user)
        {
            return await _userApplicationService.UpdateUser(id, user);
        }
    }
}
