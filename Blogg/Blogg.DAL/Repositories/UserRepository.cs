using Blogg.Core.Entities;
using Blogg.Core.Repositories;
using Blogg.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Blogg.DAL.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    readonly BloggDbContext _context;
    public UserRepository(BloggDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
    }

    public User GetCurrentUser()
    {
        //TODO: GetCurrentUser
        return new();
    }
}
