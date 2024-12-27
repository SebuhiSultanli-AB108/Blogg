using Blogg.Core.Entities;

namespace Blogg.Core.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    User GetCurrentUser();
    Task<User?> GetByUsernameAsync(string username);
}
