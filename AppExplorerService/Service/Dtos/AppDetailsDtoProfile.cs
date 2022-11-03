using AutoMapper;
using Domain;

namespace Service.Dtos
{
    public class AppDetailsDtoProfile : Profile
    {
        protected AppDetailsDtoProfile()
        {
            CreateMap<App, AppDetailsDto>()
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.AppInfo.ImagePath))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.AppInfo.Description))
                .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(src => src.AppInfo.ShortDescription));
        }
    }
}
