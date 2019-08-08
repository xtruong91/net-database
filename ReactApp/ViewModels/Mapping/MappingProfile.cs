using AutoMapper;
using ReactApp.Models;
using ReactApp.ViewModels.Stories;

namespace ReactApp.ViewModels.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Story, StoryDetailViewModel>()
                .ForMember(s => s.OwnerUsername, map => map.MapFrom(s => s.Owner.Username));
            CreateMap<Story, DraftViewModel>();
            CreateMap<Story, StoryViewModel>();

            CreateMap<Story, StoryViewModel>()
                .ForMember(s => s.OwnerUsername, map => map.MapFrom(s => s.Owner.Username));
        }
    }
}
