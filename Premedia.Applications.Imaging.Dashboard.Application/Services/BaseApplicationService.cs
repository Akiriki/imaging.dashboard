using Premedia.Applications.Imaging.Dashboard.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
