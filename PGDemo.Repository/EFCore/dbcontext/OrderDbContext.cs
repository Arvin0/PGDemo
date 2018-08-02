using Microsoft.EntityFrameworkCore;
using PGDemo.Model;

namespace PGDemo.Repository.EFCore.dbcontext
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        public DbSet<OrderModel> Order { get; set; }
        public DbSet<OrderItemModel> OrderItems { get; set; }
        public DbSet<ProductModel> Product { get; set; }
    }
}
