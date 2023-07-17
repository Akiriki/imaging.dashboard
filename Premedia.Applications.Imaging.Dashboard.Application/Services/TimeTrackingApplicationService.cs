using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Contracts;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using Premedia.Applications.Imaging.Dashboard.Persistence;
using Premedia.Applications.Imaging.Dashboard.Persistence.Contracts;
using AutoMapper;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;
using Premedia.Applications.Imaging.Dashboard.Application.Commands;
using Premedia.Applications.Imaging.Dashboard.Core.Exceptions;

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

        public async Task<ActionResult<List<TimeTrackingReadModel>>> GetTimeTrackingsByEditor(User editor)
        {
            var timeTrackings = await _unitOfWork.TimeTrackingRepository.GetMultipleAsync(x => x.Editor == editor);
            return _mapper.Map<List<TimeTrackingReadModel>>(timeTrackings);
        }

        public async Task<ActionResult<TimeTrackingReadModel>> GetTimeTrackingById(Guid id)
        {
            var timeTracking = await _unitOfWork.TimeTrackingRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<TimeTrackingReadModel>(timeTracking);
        }

        public async Task<ActionResult<List<TimeTrackingReadModel>>> GetAllTimeTrackings()
        {
            var timeTrackings = await _unitOfWork.TimeTrackingRepository.GetAllAsync();
            return _mapper.Map<List<TimeTrackingReadModel>>(timeTrackings);
        }

        public async Task<ActionResult<TimeTrackingReadModel>> CreateTimeTracking(CreateTimeTrackingCommand command)
        {
            var timeTracking = _mapper.Map<TimeTracking>(command);
            await _unitOfWork.TimeTrackingRepository.AddAsync(timeTracking);
            await _unitOfWork.SaveChangesAsync();

            var result = _mapper.Map<TimeTrackingReadModel>(timeTracking);
            return result;
        }

        public async Task<ActionResult<TimeTrackingReadModel>> UpdateTimeTracking(UpdateTimeTrackingCommand command)
        {
            var existingTimeTracking = await _unitOfWork.TimeTrackingRepository.GetFirstOrDefaultAsync(x => x.Id == command.Id);
            if (existingTimeTracking == null)
            {
                throw HttpResponseException.NotFound("Time Tracking");
            }

            _mapper.Map(command, existingTimeTracking);
            await _unitOfWork.SaveChangesAsync();

            var result = _mapper.Map<TimeTrackingReadModel>(existingTimeTracking);
            return result;
        }
    }
}