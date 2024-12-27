using Blogg.Core.Entities;
using Blogg.Core.Repositories;
using Blogg.DAL.Context;

namespace Blogg.DAL.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(BloggDbContext _context) : base(_context) { }
}
