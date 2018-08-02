using Microsoft.EntityFrameworkCore;
using PGDemo.Model;

namespace PGDemo.Repository.EFCore.dbcontext
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<ProductModel> ProductModels { get; set; }
    }
}
