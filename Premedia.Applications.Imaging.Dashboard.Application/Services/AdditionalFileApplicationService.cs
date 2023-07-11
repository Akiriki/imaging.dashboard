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

        public async Task<ActionResult<AdditionalFileReadModel>> CreateAdditionalFile(AdditionalFile additionalFileEntity)
        {
            var additionalFile = _mapper.Map<AdditionalFile>(additionalFileEntity);
            await _unitOfWork.AdditionalFileRepository.AddAsync(additionalFile);
            await _unitOfWork.SaveChangesAsync();

            var createdModel = _mapper.Map<AdditionalFileReadModel>(additionalFile);
            return createdModel;
        }

        public async Task<ActionResult<AdditionalFileReadModel>> UpdateAdditionalFile(Guid id, AdditionalFile additionalFileEntity)
        {
            var existingFile = await _unitOfWork.AdditionalFileRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            if (existingFile == null)
            {
                return null;
            }

            _mapper.Map(additionalFileEntity, existingFile);
            await _unitOfWork.SaveChangesAsync();

            var updatedModel = _mapper.Map<AdditionalFileReadModel>(existingFile);
            return updatedModel;
        }
    }
}
