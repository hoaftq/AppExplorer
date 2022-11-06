using AutoMapper;
using Domain;

namespace Service.Dtos
{
    public class LanguageDtoProfile : Profile
    {
        public LanguageDtoProfile()
        {
            CreateMap<Language, LanguageDto>();
            CreateMap<LanguageDto, Language>();
        }
    }
}
