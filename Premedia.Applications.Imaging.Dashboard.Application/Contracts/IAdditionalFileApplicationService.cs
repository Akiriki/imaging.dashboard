﻿using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Application.Contracts
{
    public interface IAdditionalFileApplicationService
    {
        Task<ActionResult<AdditionalFileReadModel>> GetAdditionalFileById(Guid id);
        Task<ActionResult<List<AdditionalFileReadModel>>> GetAllAdditionalFiles();

        Task<ActionResult<AdditionalFileReadModel>> CreateAdditionalFile(AdditionalFile additionalFileEntity);
        Task<ActionResult<AdditionalFileReadModel>> UpdateAdditionalFile(Guid id, AdditionalFile additionalFileEntity);
    }
}