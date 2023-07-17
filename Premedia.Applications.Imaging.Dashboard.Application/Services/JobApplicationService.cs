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
    public class JobApplicationService : BaseApplicationService, IJobApplicationService
    {
        private readonly ImagingDashboardDbContext _dbContext;
        private readonly IMapper _mapper;

        public JobApplicationService(IUnitOfWork unitOfWork, ImagingDashboardDbContext dbContext, IMapper mapper):base(unitOfWork)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<JobReadModel>>> GetNewJobs()
        {
            var jobs = await _unitOfWork.JobRepository.GetMultipleAsync(x => x.Editor == null);
            return _mapper.Map<List<JobReadModel>>(jobs);
        }

        public async Task<ActionResult<List<JobReadModel>>> GetAllJobs()
        {
            var jobs = await _unitOfWork.JobRepository.GetAllAsync();
            return _mapper.Map<List<JobReadModel>>(jobs);
        }

        public async Task<ActionResult<JobReadModel>> GetJobById(Guid id)
        {
            var jobs = await _unitOfWork.JobRepository.GetFirstOrDefaultAsync(x => x.Id==id);
            return _mapper.Map<JobReadModel>(jobs);
        }

        public async Task<ActionResult<List<JobReadModel>>> GetJobsByEditor(User editor)
        {
            var jobs = await _unitOfWork.JobRepository.GetMultipleAsync(x => x.Editor==editor);
            return _mapper.Map<List<JobReadModel>>(jobs);
        }
        public async Task<ActionResult<JobReadModel>> CreateJob(CreateJobCommand jobEntity)
        {
            var job = _mapper.Map<Job>(jobEntity);
            await _unitOfWork.JobRepository.AddAsync(job);
            await _unitOfWork.SaveChangesAsync();

            var createdModel = _mapper.Map<JobReadModel>(job);
            return createdModel;
        }

        public async Task<ActionResult<JobReadModel>> UpdateJob(Guid id, UpdateJobCommand command)
        {
            var existingJob = await _unitOfWork.JobRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            if (existingJob == null)
            {
                return null;
            }

            _mapper.Map(command, existingJob);
            await _unitOfWork.SaveChangesAsync();

            var updatedModel = _mapper.Map<JobReadModel>(existingJob);
            return updatedModel;
        }

        public async Task<ActionResult<JobReadModel>> ChangeEditor(Guid id, UpdateJobEditorCommand command)
        {
            var existingJob = await _unitOfWork.JobRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            if (existingJob == null)
            {
                return null;
            }


            _mapper.Map(command, existingJob.Editor);
            await _unitOfWork.SaveChangesAsync();

            var updatedModel = _mapper.Map<JobReadModel>(existingJob);
            return updatedModel;
        }
    }
}
