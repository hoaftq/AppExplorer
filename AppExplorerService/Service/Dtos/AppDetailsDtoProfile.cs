using AutoMapper;
using Domain;

namespace Service.Dtos
{
    public class AppDetailsDtoProfile : Profile
    {
        public AppDetailsDtoProfile()
        {
            CreateMap<App, AppDetailsDto>();
            CreateMap<AppDetailsDto, App>();
        }
    }

    public class AppInfoDtoProfile : Profile
    {
        public AppInfoDtoProfile()
        {
            CreateMap<AppInfo, AppInfoDto>();
            CreateMap<AppInfoDto, AppInfo>();
        }
    }

    public class AppUrlsDtoProfile : Profile
    {
        public AppUrlsDtoProfile()
        {
            CreateMap<AppUrls, AppUrlsDto>();
            CreateMap<AppUrlsDto, AppUrls>();
        }
    }
}
