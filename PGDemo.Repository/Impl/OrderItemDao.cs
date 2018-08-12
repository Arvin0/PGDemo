using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PGDemo.DBModel;
using PGDemo.Repository.EFCore.DBContexts;

namespace PGDemo.Repository.Impl
{
    public class OrderItemDao : BaseRepository<OrderItem>, IOrderItemDao
    {
        #region Constructor

        public OrderItemDao(PGDemoDbContext dbContext) : base(dbContext)
        {
        }

        #endregion

        public IList<OrderItem> Get(bool include)
        {
            if (include)
            {
                return DbContext.OrderItem
                    .Include(item => item.Product)
                    .ToList();
            }

            return Get();
        }

        public OrderItem Get(int id, bool include)
        {
            if (include)
            {
                return DbContext.OrderItem
                    .Include(item => item.Product)
                    .FirstOrDefault(o => o.Id == id);
            }

            return Get(id);
        }

        public IList<OrderItem> Get(Expression<Func<OrderItem, bool>> whereExpression, bool include)
        {
            if (include)
            {
                return DbContext.OrderItem
                    .Include(item => item.Product)
                    .Where(whereExpression)
                    .ToList();
            }

            return Get(whereExpression);
        }
    }
}
