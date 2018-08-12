using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PGDemo.DBModel;
using PGDemo.DependencyInjection;

namespace PGDemo.Repository
{
    public interface IOrderItemDao : IBaseRepository<OrderItem>, IDependency
    {
        IList<OrderItem> Get(bool include);

        Task<List<OrderItem>> GetAsync(bool include);

        OrderItem Get(int id, bool include);

        Task<OrderItem> GetAsync(int id, bool include);

        IList<OrderItem> Get(Expression<Func<OrderItem, bool>> whereExpression, bool include);

        Task<List<OrderItem>> GetAsync(Expression<Func<OrderItem, bool>> whereExpression, bool include);
    }
}
