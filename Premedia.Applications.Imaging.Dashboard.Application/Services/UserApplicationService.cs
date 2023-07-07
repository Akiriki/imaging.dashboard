using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Contracts;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using Premedia.Applications.Imaging.Dashboard.Persistence;
using Premedia.Applications.Imaging.Dashboard.Persistence.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Application.Services
{
    public class UserApplicationService : BaseApplicationService, IUserApplicationService
    {
        private readonly ImagingDashboardDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserApplicationService(IUnitOfWork unitOfWork, ImagingDashboardDbContext dbContext, IMapper mapper) : base(unitOfWork)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<UserReadModel>>> GetUser()
        {
            var user = await _unitOfWork.UserRepository.GetMultipleAsync();
            return _mapper.Map<List<UserReadModel>>(user);
        }
    }
}

