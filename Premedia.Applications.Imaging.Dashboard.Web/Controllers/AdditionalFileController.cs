using Microsoft.AspNetCore.Mvc;
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

        [HttpGet(nameof(GetAdditionalFilesById))]
        public async Task<ActionResult<List<AdditionalFileReadModel>>> GetAdditionalFilesById(Guid id)
        {
            return await _additionalFileApplicationService.GetAdditionalFilesById(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<AdditionalFileReadModel>>> GetAllAdditionalFiles()
        {
            return await _additionalFileApplicationService.GetAllAdditionalFiles();
        }

        [HttpPost]
        public async Task<ActionResult<AdditionalFileReadModel>> CreateAdditionalFiles(AdditionalFile additionalFile)
        {
            return await _additionalFileApplicationService.CreateAdditionalFile(additionalFile);
        }

        [HttpPut]
        public async Task<ActionResult<AdditionalFileReadModel>> UpdateAdditionalFiles(Guid id, AdditionalFile additionalFile)
        {
            return await _additionalFileApplicationService.UpdateAdditionalFile(id, additionalFile);
        }
    }
}
