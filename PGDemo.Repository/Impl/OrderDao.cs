using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    }
}
