using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Commands;
using Premedia.Applications.Imaging.Dashboard.Application.Contracts;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;
using Premedia.Applications.Imaging.Dashboard.Core.Exceptions;
using Premedia.Applications.Imaging.Dashboard.Persistence.Contracts;
using Premedia.Applications.Imaging.Dashboard.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Application.Services
{
    public class ActivityApplicationService : BaseApplicationService, IActivityApplicationService
    {
        private readonly ImagingDashboardDbContext _dbContext;
        private readonly IMapper _mapper;

        public ActivityApplicationService(IUnitOfWork unitOfWork, ImagingDashboardDbContext dbContext, IMapper mapper) : base(unitOfWork)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<ActivityReadModel>> GetActivityById(Guid id)
        {
            var activity = await _unitOfWork.ActivityRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ActivityReadModel>(activity);
        }

        public async Task<ActionResult<List<ActivityReadModel>>> GetAllActivities()
        {
            var activity = await _unitOfWork.ActivityRepository.GetAllAsync();
            return _mapper.Map<List<ActivityReadModel>>(activity);
        }

        public async Task<ActionResult<ActivityReadModel>> CreateActivity(CreateActivityCommand command)
        {
            var activity = _mapper.Map<Activity>(command);
            await _unitOfWork.ActivityRepository.AddAsync(activity);
            await _unitOfWork.SaveChangesAsync();

            var result = _mapper.Map<ActivityReadModel>(activity);
            return result;
        }

        public async Task<ActionResult<ActivityReadModel>> UpdateActivity(UpdateActivityCommand command)
        {
            var activity = await _unitOfWork.ActivityRepository.GetFirstOrDefaultAsync(x => x.Id == command.Id);
            if (activity == null)
            {
                throw HttpResponseException.NotFound("Activity");
            }

            _mapper.Map(command, activity);
            await _unitOfWork.SaveChangesAsync();

            var result = _mapper.Map<ActivityReadModel>(activity);
            return result;
        }

        public async Task<ActionResult<ActivityReadModel>> DeleteActivity(Guid id)
        {
            var activity = await _unitOfWork.ActivityRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            if (activity == null)
            {
                throw HttpResponseException.NotFound("Activity");
            }

            _unitOfWork.ActivityRepository.Remove(activity);
            await _unitOfWork.SaveChangesAsync();

            var result = _mapper.Map<ActivityReadModel>(activity);
            return result;
        }
    }
}
