using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ObjectRelationMapping.EntityFramework.Config
{
    public class EfApplicationContext : DbContext
    {
        public EfApplicationContext(DbContextOptions<EfApplicationContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
