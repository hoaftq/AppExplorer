using AutoMapper;
using Domain;

namespace Service.Dtos
{
    public class AppDtoProfile : Profile
    {
        protected AppDtoProfile()
        {
            CreateMap<App, AppDto>()
                .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(src => src.AppInfo.ShortDescription))
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.AppInfo.ImagePath));
        }
    }
}
