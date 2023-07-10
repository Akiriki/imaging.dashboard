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
    }
}
