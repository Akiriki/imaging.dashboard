using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Commands;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;

namespace Premedia.Applications.Imaging.Dashboard.Application.Contracts
{
    public interface IAdditionalFileApplicationService
    {
        Task<ActionResult<AdditionalFileReadModel>> GetAdditionalFileById(Guid id);
        Task<ActionResult<List<AdditionalFileReadModel>>> GetAllAdditionalFiles();
        Task<ActionResult<AdditionalFileReadModel>> CreateAdditionalFile(CreateAdditionalFileCommand command);
        Task<ActionResult<AdditionalFileReadModel>> UpdateAdditionalFile(UpdateAdditionalFileCommand command);
    }
}