using Blogg.Core.Entities;

namespace Blogg.Core.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<int> Register(User user);
    Task<User?> GetByUsernameOrEmailAsync(string value);
}
