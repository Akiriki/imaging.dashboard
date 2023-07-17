using AutoMapper;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;

namespace Premedia.Applications.Imaging.Dashboard.Application.Mappings
{
    public class TimeTrackingMapping : Profile
    {
        public TimeTrackingMapping()
        {
            CreateMap<TimeTrackingReadModel, TimeTracking>().ReverseMap();
        }
    }
}