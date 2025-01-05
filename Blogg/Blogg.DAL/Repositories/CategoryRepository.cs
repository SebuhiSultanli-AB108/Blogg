using Blogg.Core.Entities;
using Blogg.Core.Repositories;
using Blogg.DAL.Context;

namespace Blogg.DAL.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    readonly BloggDbContext _context;
    public CategoryRepository(BloggDbContext context) : base(context)
    {
        _context = context;
    }
}
