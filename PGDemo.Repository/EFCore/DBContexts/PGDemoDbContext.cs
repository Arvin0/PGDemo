using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PGDemo.Common;
using PGDemo.DependencyInjection.IocFlag;
using PGDemo.Log.EFLog;
using PGDemo.DBModel;

namespace PGDemo.Repository.EFCore.DBContexts
{
    public class PGDemoDbContext : DbContext, IInstanceDependency
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var logger = new LoggerFactory();
            logger.AddProvider(new EFLoggerProvider());

            optionsBuilder.UseNpgsql(ConfigHelper.GetValueForMigration<string>("ConnectionStrings:PGDemo"))
                .UseLoggerFactory(logger);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 配置Order,OrderItem 1对多关系
            modelBuilder.Entity<Order>()
                .HasMany<OrderItem>(o => o.OrderItems)
                .WithOne(item => item.Order)
                .HasForeignKey(item => item.OrderId)
                .OnDelete(DeleteBehavior.Cascade); //设置级联删除

            // 配置OrderItem, Product 多对1关系; 从某种层面分析，不应在Product中配置OrderItem集合，
            // 故不在此配置两个表的关系，而是直接在实体中配置
                
            base.OnModelCreating(modelBuilder);
        }

        #region DbSet

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Product> Product { get; set; }

        #endregion
    }
}
