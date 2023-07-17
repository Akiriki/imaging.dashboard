using AutoMapper;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;

namespace Premedia.Applications.Imaging.Dashboard.Application.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<UserReadModel, User>().ReverseMap();
        }

    }
}