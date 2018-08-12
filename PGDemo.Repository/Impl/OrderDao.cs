using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PGDemo.DBModel;
using PGDemo.Repository.EFCore.DBContexts;

namespace PGDemo.Repository.Impl
{
    public class OrderDao : BaseRepository<Order>, IOrderDao
    {
        #region Constructor

        public OrderDao(PGDemoDbContext dbContext) : base(dbContext)
        {
        }

        #endregion

        public IList<Order> Get(bool include)
        {
            if (include)
            {
                return DbContext.Order
                    .Include(o => o.OrderItems)
                    .ThenInclude(item => item.Product)
                    .ToList();
            }

            return Get();
        }

        public Task<List<Order>> GetAsync(bool include)
        {
            if (include)
            {
                return DbContext.Order
                    .Include(o => o.OrderItems)
                    .ThenInclude(item => item.Product)
                    .ToListAsync();
            }

            return GetAsync();
        }

        public Order Get(int id, bool include)
        {
            if (include)
            {
                return DbContext.Order
                    .Include(o => o.OrderItems)
                    .ThenInclude(item => item.Product)
                    .FirstOrDefault(o => o.Id == id);
            }

            return Get(id);
        }

        public Task<Order> GetAsync(int id, bool include)
        {
            if (include)
            {
                return DbContext.Order
                    .Include(o => o.OrderItems)
                    .ThenInclude(item => item.Product)
                    .FirstOrDefaultAsync(o => o.Id == id);
            }

            return GetAsync(id);
        }

        public IList<Order> Get(Expression<Func<Order, bool>> whereExpression, bool include)
        {
            if (include)
            {
                return DbContext.Order
                    .Include(o => o.OrderItems)
                    .ThenInclude(item => item.Product)
                    .Where(whereExpression)
                    .ToList();
            }

            return Get(whereExpression);
        }

        public Task<List<Order>> GetAsync(Expression<Func<Order, bool>> whereExpression, bool include)
        {
            if (include)
            {
                return DbContext.Order
                    .Include(o => o.OrderItems)
                    .ThenInclude(item => item.Product)
                    .Where(whereExpression)
                    .ToListAsync();
            }

            return GetAsync(whereExpression);
        }
    }
}
