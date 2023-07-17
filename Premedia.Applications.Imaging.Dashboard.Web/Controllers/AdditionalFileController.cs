using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Commands;
using Premedia.Applications.Imaging.Dashboard.Application.Contracts;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationFilesController : ControllerBase
    {
        private readonly IAdditionalFileApplicationService _additionalFileApplicationService;
        public ApplicationFilesController(IAdditionalFileApplicationService additionalFileApplicationService)
        {
            _additionalFileApplicationService = additionalFileApplicationService;
        }

        [HttpGet(nameof(GetAdditionalFileById))]
        public async Task<ActionResult<AdditionalFileReadModel>> GetAdditionalFileById(Guid id)
        {
            return await _additionalFileApplicationService.GetAdditionalFileById(id);
        }

        [HttpGet(nameof(GetAllAdditionalFiles))]
        public async Task<ActionResult<List<AdditionalFileReadModel>>> GetAllAdditionalFiles()
        {
            return await _additionalFileApplicationService.GetAllAdditionalFiles();
        }

        [HttpPost]
        public async Task<ActionResult<AdditionalFileReadModel>> CreateAdditionalFile(CreateAdditionalFileCommand command)
        {
            return await _additionalFileApplicationService.CreateAdditionalFile(command);
        }

        [HttpPut]
        public async Task<ActionResult<AdditionalFileReadModel>> UpdateAdditionalFile(Guid id, UpdateAdditionalFileCommand command)
        {
            return await _additionalFileApplicationService.UpdateAdditionalFile(id, command);
        }
    }
}
