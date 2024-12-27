using AutoMapper;
using Blogg.BL.DTOs.CategoryDTOs;
using Blogg.Core.Entities;
using Blogg.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Blogg.BL.Services.CategoryService;

public class CategoryService(ICategoryRepository _repository, IMapper _mapper) : ICategoryService
{
    public async Task<int> CreateAsync(CategoryCreateDTO dto)
    {
        var category = _mapper.Map<Category>(dto);
        await _repository.AddAsync(category);
        await _repository.SaveAsync();
        return category.Id;
    }

    public async Task<IEnumerable<CategoryListItemDTO>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<CategoryListItemDTO>>(await _repository.GetAll().ToListAsync());
    }
}
