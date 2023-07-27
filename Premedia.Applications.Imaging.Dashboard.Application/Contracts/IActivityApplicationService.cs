using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Premedia.Applications.Imaging.Dashboard.Application.Commands;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using Premedia.Applications.Imaging.Dashboard.Core.Exceptions;
using Premedia.Applications.Imaging.Dashboard.Persistence.Contracts;
using Premedia.Applications.Imaging.Dashboard.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Application.Contracts
{
    public interface IActivityApplicationService
    {

        Task<ActionResult<ActivityReadModel>> GetActivityById(Guid id);
        Task<ActionResult<List<ActivityReadModel>>> GetAllActivities();
        Task<ActionResult<ActivityReadModel>> CreateActivity(CreateActivityCommand command);
        Task<ActionResult<ActivityReadModel>> UpdateActivity(UpdateActivityCommand command);
    }
}
