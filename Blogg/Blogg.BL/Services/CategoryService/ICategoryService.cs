using Blogg.BL.DTOs.CategoryDTOs;

namespace Blogg.BL.Services.CategoryService;

public interface ICategoryService
{
    Task<IEnumerable<CategoryListItemDTO>> GetAllAsync();
    Task<int> CreateAsync(CategoryCreateDTO dto);
}
