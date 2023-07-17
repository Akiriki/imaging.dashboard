using AutoMapper;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;

namespace Premedia.Applications.Imaging.Dashboard.Application.Mappings
{
    public class JobFileMapping : Profile
    {
        public JobFileMapping()
        {
            CreateMap<JobFileReadModel, UpdateJobFilesCommand>().ReverseMap();
        }

    }
}