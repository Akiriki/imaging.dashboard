using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Contracts;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using Premedia.Applications.Imaging.Dashboard.Persistence;
using Premedia.Applications.Imaging.Dashboard.Persistence.Contracts;
using AutoMapper;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;
using Premedia.Applications.Imaging.Dashboard.Application.Commands;

namespace Premedia.Applications.Imaging.Dashboard.Application.Services
{
    public class HistoryApplicationService : BaseApplicationService, IHistoryApplicationService
    {
        private readonly ImagingDashboardDbContext _dbContext;
        private readonly IMapper _mapper;

        public HistoryApplicationService(IUnitOfWork unitOfWork, ImagingDashboardDbContext dbContext, IMapper mapper) : base(unitOfWork)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<HistoryReadModel>>> GetChangedHistories()
        {
            var history = await _unitOfWork.HistoryRepository.GetMultipleAsync(x => x.NewValue != null);
            return _mapper.Map<List<HistoryReadModel>>(history);
        }

        public async Task<ActionResult<HistoryReadModel>> GetHistoryById(Guid id)
        {
            var history = await _unitOfWork.HistoryRepository.GetFirstOrDefaultAsync(x => x.Id != id);
            return _mapper.Map<HistoryReadModel>(history);
        }

        public async Task<ActionResult<List<HistoryReadModel>>> GetAllHistories()
        {
            var history = await _unitOfWork.HistoryRepository.GetAllAsync();
            return _mapper.Map<List<HistoryReadModel>>(history);
        }

        public async Task<ActionResult<HistoryReadModel>> CreateHistory(CreateHistoryCommand command)
        {
            var history = _mapper.Map<History>(command);
            await _unitOfWork.HistoryRepository.AddAsync(history);
            await _unitOfWork.SaveChangesAsync();

            var createdModel = _mapper.Map<HistoryReadModel>(history);
            return createdModel;
        }

        public async Task<ActionResult<HistoryReadModel>> UpdateHistory(Guid id, UpdateHistoryCommand command)
        {
            var existingHistory = await _unitOfWork.HistoryRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            if (existingHistory == null)
            {
                return null;
            }
            
            _mapper.Map(command, existingHistory);
            await _unitOfWork.SaveChangesAsync();

            var updatedModel = _mapper.Map<HistoryReadModel>(existingHistory);
            return updatedModel;
        }
    }
}