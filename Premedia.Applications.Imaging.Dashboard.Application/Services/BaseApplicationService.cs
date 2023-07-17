using Premedia.Applications.Imaging.Dashboard.Persistence.Contracts;

namespace Premedia.Applications.Imaging.Dashboard.Application.Services
{
    public class BaseApplicationService
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseApplicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
