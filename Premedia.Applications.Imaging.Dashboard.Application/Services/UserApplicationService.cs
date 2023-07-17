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
using Premedia.Applications.Imaging.Dashboard.Core.Entities;
using Premedia.Applications.Imaging.Dashboard.Application.Commands;

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

        public async Task<ActionResult<List<UserReadModel>>> GetAllUsers()
        {
            var user = await _unitOfWork.UserRepository.GetAllAsync();
            return _mapper.Map<List<UserReadModel>>(user);
        }
        public async Task<ActionResult<UserReadModel>> GetUserById(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetFirstOrDefaultAsync(x => x.Id==id);
            return _mapper.Map<UserReadModel>(user);
        }

        public async Task<ActionResult<UserReadModel>> CreateUser(CreateUserCommand command)
        {
            var user = _mapper.Map<User>(command);
            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            var createdModel = _mapper.Map<UserReadModel>(user);
            return createdModel;
        }

        public async Task<ActionResult<UserReadModel>> UpdateUser(Guid id, UpdateUserCommand command)
        {
            var existingUser = await _unitOfWork.UserRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            if (existingUser == null)
            {
                return null;
            }

            _mapper.Map(command, existingUser);
            await _unitOfWork.SaveChangesAsync();

            var updatedModel = _mapper.Map<UserReadModel>(existingUser);
            return updatedModel;
        }
    }
}

