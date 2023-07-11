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
            //var jobfiles = await _unitOfWork.JobFileRepository.GetMultipleAsync(x => x.Status == Core.Enums.Status.ToDo);
            //return _mapper.Map<List<JobFileReadModel>>(jobfiles);
            return null;
        }

        public async Task<ActionResult<List<JobFileReadModel>>> GetAllJobFiles()
        {
            var jobfiles = await _unitOfWork.JobFileRepository.GetMultipleAsync();
            return _mapper.Map<List<JobFileReadModel>>(jobfiles);
        }

        public async Task<ActionResult<List<JobFileReadModel>>> GetJobFilesById(Guid id)
        {
            var jobfiles = await _unitOfWork.JobFileRepository.GetMultipleAsync(x => x.Id == id);
            return _mapper.Map<List<JobFileReadModel>>(jobfiles);
        }

        public async Task<ActionResult<JobFileReadModel>> CreateJobFile(JobFiles jobFileEntity)
        {
            var jobFile = _mapper.Map<JobFiles>(jobFileEntity);
            await _unitOfWork.JobFileRepository.AddAsync(jobFile);
            await _unitOfWork.SaveChangesAsync();

            var createdModel = _mapper.Map<JobFileReadModel>(jobFile);
            return createdModel;
        }

        public async Task<ActionResult<JobFileReadModel>> UpdateJobFile(Guid id, JobFiles jobFileEntity)
        {
            var existingJobFile = await _unitOfWork.JobFileRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            if (existingJobFile == null)
            {
                return null;
            }

            _mapper.Map(jobFileEntity, existingJobFile);
            await _unitOfWork.SaveChangesAsync();

            var updatedModel = _mapper.Map<JobFileReadModel>(existingJobFile);
            return updatedModel;
        }
    }
}
