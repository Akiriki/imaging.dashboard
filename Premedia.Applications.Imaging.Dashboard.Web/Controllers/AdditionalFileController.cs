using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Contracts;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Controllers
{
    [ApiController]
    public class ApplicationFilesController : ControllerBase
    {
        private readonly IAdditionalFileApplicationService _additionalFileApplicationService;
        public ApplicationFilesController(IAdditionalFileApplicationService additionalFileApplicationService)
        {
            _additionalFileApplicationService = additionalFileApplicationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdditionalFileReadModel>>> GetNewAdditionalFiles()
        {
            return await _additionalFileApplicationService.GetNewAdditionalFiles();
        }
    }
}
