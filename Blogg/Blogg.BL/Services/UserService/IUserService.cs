namespace Blogg.BL.Services.UserService;

public interface IUserService
{
    Task<int> CreateAsync();
    Task DeleteAsync(int id);
}
