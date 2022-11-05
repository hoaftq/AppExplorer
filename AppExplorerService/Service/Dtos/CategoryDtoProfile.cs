using AutoMapper;
using Domain;

namespace Service.Dtos
{
    public class CategoryDtoProfile : Profile
    {
        public CategoryDtoProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
