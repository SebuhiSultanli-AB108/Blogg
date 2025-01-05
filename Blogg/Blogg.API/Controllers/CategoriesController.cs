using Blogg.BL.DTOs.CategoryDTOs;
using Blogg.BL.Services.CategoryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogg.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService _service) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryCreateDTO dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }
    }
}
