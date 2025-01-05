using Blogg.BL.DTOs.UserDTOs;
using Blogg.Core.Entities;

namespace Blogg.BL.Services.UserService;

public interface IUserService
{
    Task<int> RegisterAsync(RegisterDTO dto);
    Task<string> LoginAsync(LoginDTO dto);
    Task DeleteAsync(int id);
    IQueryable<User> GetAll();
}
