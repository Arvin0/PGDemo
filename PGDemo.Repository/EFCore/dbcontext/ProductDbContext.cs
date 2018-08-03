using Microsoft.EntityFrameworkCore;
using PGDemo.Model;

namespace PGDemo.Repository.EFCore.dbcontext
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext()
        {
        }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> ProductModels { get; set; }
    }
}
