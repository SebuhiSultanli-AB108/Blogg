using AutoMapper;
using Blogg.BL.DTOs.CategoryDTOs;
using Blogg.Core.Entities;

namespace Blogg.BL.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CategoryCreateDTO, Category>().ReverseMap();
        CreateMap<CategoryListItemDTO, Category>().ReverseMap();
    }
}
