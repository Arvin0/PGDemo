using Microsoft.EntityFrameworkCore;

namespace PGDemo.Repository.EFCore.dbcontext
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext( DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }
    }
}
