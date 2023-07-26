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
    public class JobApplicationService : BaseApplicationService, IJobApplicationService
    {
        private readonly ImagingDashboardDbContext _dbContext;
        private readonly IMapper _mapper;

        public JobApplicationService(IUnitOfWork unitOfWork, ImagingDashboardDbContext dbContext, IMapper mapper) : base(unitOfWork)
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
            var job = await _unitOfWork.JobRepository.GetFirstOrDefaultAsync(x => x.Id == id,
                x => x.Include(y => y.Client)
                .Include(y => y.Editor));
            return _mapper.Map<JobReadModel>(job);
        }

        public async Task<ActionResult<List<JobReadModel>>> GetJobsByEditor(User editor)
        {
            var jobs = await _unitOfWork.JobRepository.GetMultipleAsync(x => x.Editor == editor);
            return _mapper.Map<List<JobReadModel>>(jobs);
        }

        public async Task<ActionResult<List<JobReadModel>>> GetJobsByEditorId(Guid id)
        {
            var jobs = await _unitOfWork.JobRepository.GetMultipleAsync(x => x.EditorId == id && x.Status != Core.Enums.Status.Done);
            return _mapper.Map<List<JobReadModel>>(jobs);
        }

        public async Task<ActionResult<List<JobReadModel>>> GetColleagueJobs(Guid id)
        {
            var jobs = await _unitOfWork.JobRepository.GetMultipleAsync(x => x.EditorId != id && x.EditorId != null && x.Status != Core.Enums.Status.Done,
                x => x.Include(y => y.Editor));
            return _mapper.Map<List<JobReadModel>>(jobs);
        }

        public async Task<ActionResult<List<JobReadModel>>> GetTransferredJobs()
        {
            var jobs = await _unitOfWork.JobRepository.GetMultipleAsync(x => x.Status == Core.Enums.Status.Transferred2Partner);
            return _mapper.Map<List<JobReadModel>>(jobs);
        }

        public async Task<ActionResult<List<JobReadModel>>> GetDoneJobs()
        {
            var jobs = await _unitOfWork.JobRepository.GetMultipleAsync(x => x.Status == Core.Enums.Status.Done,
                x => x.Include(y => y.Editor));
            return _mapper.Map<List<JobReadModel>>(jobs);
        }

        public async Task<ActionResult<JobReadModel>> CreateJob(CreateJobCommand command)
        {
            var job = _mapper.Map<Job>(command);
            await _unitOfWork.JobRepository.AddAsync(job);
            await _unitOfWork.SaveChangesAsync();

            var result = _mapper.Map<JobReadModel>(job);
            return result;
        }

        public async Task<ActionResult<JobReadModel>> UpdateJob(UpdateJobCommand command)
        {
            var existingJob = await _unitOfWork.JobRepository.GetFirstOrDefaultAsync(x => x.Id == command.Id);
            if (existingJob == null)
            {
                throw HttpResponseException.NotFound("Job");
            }

            _mapper.Map(command, existingJob);
            await _unitOfWork.SaveChangesAsync();

            var result = _mapper.Map<JobReadModel>(existingJob);
            return result;
        }

        public async Task<ActionResult<JobReadModel>> ChangeEditor(UpdateJobEditorCommand command)
        {
            var job = await _unitOfWork.JobRepository.GetFirstOrDefaultAsync(x => x.Id == command.Id);
            if (job == null)
            {
                throw HttpResponseException.NotFound("Job");
            }


            _mapper.Map(command, job.Editor);
            await _unitOfWork.SaveChangesAsync();

            var result = _mapper.Map<JobReadModel>(job);
            return result;
        }
    }
}