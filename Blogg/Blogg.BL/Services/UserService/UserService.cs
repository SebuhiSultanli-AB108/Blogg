
using Blogg.Core.Repositories;

namespace Blogg.BL.Services.UserService;

public class UserService(IUserRepository _repository) : IUserService
{
    public async Task<int> CreateAsync()
    {
        //await _repository.AddAsync()
        return new();
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.GetByIdAsync(id);
    }
}
