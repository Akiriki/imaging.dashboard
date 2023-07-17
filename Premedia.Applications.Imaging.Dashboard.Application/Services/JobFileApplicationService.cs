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
    public class JobFileApplicationService : BaseApplicationService, IJobFileApplicationService
    {
        private readonly ImagingDashboardDbContext _dbContext;
        private readonly IMapper _mapper;

        public JobFileApplicationService(IUnitOfWork unitOfWork, ImagingDashboardDbContext dbContext, IMapper mapper) : base(unitOfWork)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<JobFileReadModel>>> GetNewJobFiles()
        {
            var jobfiles = await _unitOfWork.JobFileRepository.GetMultipleAsync(x => x.Status == Core.Enums.Status.ToDo);
            return _mapper.Map<List<JobFileReadModel>>(jobfiles);
        }

        public async Task<ActionResult<List<JobFileReadModel>>> GetAllJobFiles()
        {
            var jobfiles = await _unitOfWork.JobFileRepository.GetAllAsync();
            return _mapper.Map<List<JobFileReadModel>>(jobfiles);
        }

        public async Task<ActionResult<JobFileReadModel>> GetJobFileById(Guid id)
        {
            var jobfiles = await _unitOfWork.JobFileRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<JobFileReadModel>(jobfiles);
        }

        public async Task<ActionResult<JobFileReadModel>> CreateJobFile(CreateJobFileCommand command)
        {
            var jobFile = _mapper.Map<UpdateJobFilesCommand>(command);
            await _unitOfWork.JobFileRepository.AddAsync(jobFile);
            await _unitOfWork.SaveChangesAsync();

            var createdModel = _mapper.Map<JobFileReadModel>(jobFile);
            return createdModel;
        }

        public async Task<ActionResult<JobFileReadModel>> UpdateJobFile(Guid id, UpdateJobFileCommand command)
        {
            var existingJobFile = await _unitOfWork.JobFileRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            if (existingJobFile == null)
            {
                return null;
            }

            _mapper.Map(command, existingJobFile);
            await _unitOfWork.SaveChangesAsync();

            var updatedModel = _mapper.Map<JobFileReadModel>(existingJobFile);
            return updatedModel;
        }
    }
}