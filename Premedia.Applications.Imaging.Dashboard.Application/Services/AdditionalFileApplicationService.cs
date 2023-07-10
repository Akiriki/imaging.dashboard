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
    public class AdditionalFileApplicationService : BaseApplicationService, IAdditionalFileApplicationService
    {
        private readonly ImagingDashboardDbContext _dbContext;
        private readonly IMapper _mapper;

        public AdditionalFileApplicationService(IUnitOfWork unitOfWork, ImagingDashboardDbContext dbContext, IMapper mapper) : base(unitOfWork)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<AdditionalFileReadModel>>> GetAdditionalFilesById(Guid id)
        {
            var additionalFiles = await _unitOfWork.AdditionalFileRepository.GetMultipleAsync(x => x.Id == id);
            return _mapper.Map<List<AdditionalFileReadModel>>(additionalFiles);
        }

        public async Task<ActionResult<List<AdditionalFileReadModel>>> GetAllAdditionalFiles()
        {
            var additionalFiles = await _unitOfWork.AdditionalFileRepository.GetMultipleAsync();
            return _mapper.Map<List<AdditionalFileReadModel>>(additionalFiles);
        }
    }
}
