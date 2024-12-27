using AutoMapper;
using Blogg.BL.DTOs.UserDTOs;
using Blogg.Core.Entities;
using Blogg.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Blogg.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserRepository _repository, IMapper _mapper) : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(UserCreateDTO dto)
    {
        await _repository.AddAsync(_mapper.Map<User>(dto));
        await _repository.SaveAsync();
        return Ok();
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(_repository.GetAll());
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetByUsername(string username)
    {
        return Ok(await _repository.GetByUsernameAsync(username));
    }


    //TODO: Finish this 

    //[HttpGet("[action]")]
    //public async Task<IActionResult> GetCurrentUser()
    //{
    //    return Ok(_repository.GetCurrentUser());
    //}
}