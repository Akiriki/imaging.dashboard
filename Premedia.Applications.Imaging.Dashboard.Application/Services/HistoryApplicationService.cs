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
    public class HistoryApplicationService : BaseApplicationService, IHistoryApplicationService
    {
        private readonly ImagingDashboardDbContext _dbContext;
        private readonly IMapper _mapper;

        public HistoryApplicationService(IUnitOfWork unitOfWork, ImagingDashboardDbContext dbContext, IMapper mapper) : base(unitOfWork)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<HistoryReadModel>>> GetChangedHistory()
        {
            var history = await _unitOfWork.HistoryRepository.GetMultipleAsync(x => x.NewValue != null);
            return _mapper.Map<List<HistoryReadModel>>(history);
        }

        public async Task<ActionResult<List<HistoryReadModel>>> GetHistoryById(Guid id)
        {
            var history = await _unitOfWork.HistoryRepository.GetMultipleAsync(x => x.Id != id);
            return _mapper.Map<List<HistoryReadModel>>(history);
        }

        public async Task<ActionResult<List<HistoryReadModel>>> GetAllHistories()
        {
            var history = await _unitOfWork.HistoryRepository.GetMultipleAsync();
            return _mapper.Map<List<HistoryReadModel>>(history);
        }
    }
}

