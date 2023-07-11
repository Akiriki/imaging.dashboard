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

namespace Premedia.Applications.Imaging.Dashboard.Application.Services
{
    public class TimeTrackingApplicationService : BaseApplicationService, ITimeTrackingApplicationService
    {
        private readonly ImagingDashboardDbContext _dbContext;
        private readonly IMapper _mapper;

        public TimeTrackingApplicationService(IUnitOfWork unitOfWork, ImagingDashboardDbContext dbContext, IMapper mapper) : base(unitOfWork)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<TimeTrackingReadModel>>> GetTimeTrackingByEditor(User editor)
        {
            //var timeTracking = await _unitOfWork.TimeTrackingRepository.GetMultipleAsync(x => x.Editor==editor);
            //return _mapper.Map<List<TimeTrackingReadModel>>(timeTracking);
            return null;
        }

        public async Task<ActionResult<List<TimeTrackingReadModel>>> GetTimeTrackingById(Guid id)
        {
            var timeTracking = await _unitOfWork.TimeTrackingRepository.GetMultipleAsync(x => x.Id==id);
            return _mapper.Map<List<TimeTrackingReadModel>>(timeTracking);
        }

        public async Task<ActionResult<List<TimeTrackingReadModel>>> GetAllTimeTrackings()
        {
            var timeTracking = await _unitOfWork.TimeTrackingRepository.GetMultipleAsync();
            return _mapper.Map<List<TimeTrackingReadModel>>(timeTracking);
        }

        public async Task<ActionResult<TimeTrackingReadModel>> CreateTimeTracking(TimeTracking timeTrackingEntity)
        {
            var timeTracking = _mapper.Map<TimeTracking>(timeTrackingEntity);
            await _unitOfWork.TimeTrackingRepository.AddAsync(timeTracking);
            await _unitOfWork.SaveChangesAsync();

            var createdModel = _mapper.Map<TimeTrackingReadModel>(timeTracking);
            return createdModel;
        }

        public async Task<ActionResult<TimeTrackingReadModel>> UpdateTimeTracking(Guid id, TimeTracking timeTrackingEntity)
        {
            var existingTimeTracking = await _unitOfWork.TimeTrackingRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            if (existingTimeTracking == null)
            {
                return null;
            }

            _mapper.Map(timeTrackingEntity, existingTimeTracking);
            await _unitOfWork.SaveChangesAsync();

            var updatedModel = _mapper.Map<TimeTrackingReadModel>(existingTimeTracking);
            return updatedModel;
        }
    }
}
