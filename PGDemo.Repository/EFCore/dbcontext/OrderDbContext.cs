using Microsoft.EntityFrameworkCore;
using PGDemo.Model;

namespace PGDemo.Repository.EFCore.dbcontext
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext() : base()
        {
        }

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
