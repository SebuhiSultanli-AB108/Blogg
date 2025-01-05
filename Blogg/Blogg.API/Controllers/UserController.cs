using Blogg.BL.DTOs.UserDTOs;
using Blogg.BL.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace Blogg.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService _service) : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Register(RegisterDTO dto)
    {
        return Ok(await _service.RegisterAsync(dto));
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginDTO dto)
    {
        return Ok(await _service.LoginAsync(dto));
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(_service.GetAll());
    }


    //TODO: Finish this 

    //[HttpGet("[action]")]
    //public async Task<IActionResult> GetCurrentUser()
    //{
    //    return Ok(_repository.GetCurrentUser());
    //}
}