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
    public class AdditionalFileApplicationService : BaseApplicationService, IAdditionalFileApplicationService
    {
        private readonly ImagingDashboardDbContext _dbContext;
        private readonly IMapper _mapper;

        public AdditionalFileApplicationService(IUnitOfWork unitOfWork, ImagingDashboardDbContext dbContext, IMapper mapper) : base(unitOfWork)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<AdditionalFileReadModel>> GetAdditionalFileById(Guid id)
        {
            var additionalFiles = await _unitOfWork.AdditionalFileRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<AdditionalFileReadModel>(additionalFiles);
        }

        public async Task<ActionResult<List<AdditionalFileReadModel>>> GetAllAdditionalFiles()
        {
            var additionalFiles = await _unitOfWork.AdditionalFileRepository.GetAllAsync();
            return _mapper.Map<List<AdditionalFileReadModel>>(additionalFiles);
        }

        public async Task<ActionResult<AdditionalFileReadModel>> CreateAdditionalFile(CreateAdditionalFileCommand command)
        {
            var additionalFile = _mapper.Map<AdditionalFile>(command);
            await _unitOfWork.AdditionalFileRepository.AddAsync(additionalFile);
            await _unitOfWork.SaveChangesAsync();

            var createdModel = _mapper.Map<AdditionalFileReadModel>(additionalFile);
            return createdModel;
        }

        public async Task<ActionResult<AdditionalFileReadModel>> UpdateAdditionalFile(Guid id, UpdateAdditionalFileCommand command)
        {
            var existingFile = await _unitOfWork.AdditionalFileRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            if (existingFile == null)
            {
                return null;
            }

            _mapper.Map(command, existingFile);
            await _unitOfWork.SaveChangesAsync();

            var updatedModel = _mapper.Map<AdditionalFileReadModel>(existingFile);
            return updatedModel;
        }
    }
}
