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
    public interface IUserApplicationService
    {
        Task<ActionResult<List<UserReadModel>>> GetUser();
        Task<ActionResult<List<UserReadModel>>> GetUserById(Guid id);
        Task<ActionResult<UserReadModel>> CreateUser(User userEntity);
        Task<ActionResult<UserReadModel>> UpdateUser(Guid id, User userEntity);
    }
}
