using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Contracts;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using Premedia.Applications.Imaging.Dashboard.Persistence;
using Premedia.Applications.Imaging.Dashboard.Persistence.Contracts;
using AutoMapper;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;
using Premedia.Applications.Imaging.Dashboard.Application.Commands;
using Premedia.Applications.Imaging.Dashboard.Core.Exceptions;
using Microsoft.EntityFrameworkCore;

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
            var jobFiles = await _unitOfWork.JobFileRepository.GetMultipleAsync(x => x.Status == Core.Enums.Status.ToDo);
            return _mapper.Map<List<JobFileReadModel>>(jobFiles);
        }

        public async Task<ActionResult<List<JobFileReadModel>>> GetAllJobFiles()
        {
            var jobFiles = await _unitOfWork.JobFileRepository.GetAllAsync();
            return _mapper.Map<List<JobFileReadModel>>(jobFiles);
        }

        public async Task<ActionResult<JobFileReadModel>> GetJobFileById(Guid id)
        {
            var jobFile = await _unitOfWork.JobFileRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<JobFileReadModel>(jobFile);
        }

        public async Task<ActionResult<List<JobFileReadModel>>> GetTransferredJobFiles()
        {
            var jobFiles = await _unitOfWork.JobFileRepository.GetMultipleAsync(x => x.Status == Core.Enums.Status.Transferred2Partner,
                x => x.Include(y => y.Job).ThenInclude(y => y.Editor));
            return _mapper.Map<List<JobFileReadModel>>(jobFiles);
        }

        public async Task<ActionResult<JobFileReadModel>> CreateJobFile(CreateJobFileCommand command)
        {
            var jobFile = _mapper.Map<JobFiles>(command);
            await _unitOfWork.JobFileRepository.AddAsync(jobFile);
            await _unitOfWork.SaveChangesAsync();

            var result = _mapper.Map<JobFileReadModel>(jobFile);
            return result;
        }

        public async Task<ActionResult<JobFileReadModel>> UpdateJobFile(UpdateJobFileCommand command)
        {
            var jobFile = await _unitOfWork.JobFileRepository.GetFirstOrDefaultAsync(x => x.Id == command.Id);
            if (jobFile == null)
            {
                throw HttpResponseException.NotFound("Job File");
            }

            _mapper.Map(command, jobFile);
            await _unitOfWork.SaveChangesAsync();

            var result = _mapper.Map<JobFileReadModel>(jobFile);
            return result;
        }
    }
}