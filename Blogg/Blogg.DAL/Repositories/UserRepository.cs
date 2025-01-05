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

    public async Task<int> Register(User user)
    {
        await AddAsync(user);
        await SaveAsync();
        User? newUser = await GetByUsernameOrEmailAsync(user.Username);
        return newUser.Id;
    }

    public async Task<User?> GetByUsernameOrEmailAsync(string value)
    {
        if (value.Contains('@'))
            return await _context.Users.Where(x => x.Email == value).FirstOrDefaultAsync();
        else
            return await _context.Users.Where(x => x.Username == value).FirstOrDefaultAsync();
    }
}