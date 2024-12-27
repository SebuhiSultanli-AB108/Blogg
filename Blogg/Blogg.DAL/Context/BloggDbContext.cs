using Blogg.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blogg.DAL.Context;

public class BloggDbContext : DbContext
{
    public BloggDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BloggDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
