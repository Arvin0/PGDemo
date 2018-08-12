using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PGDemo.DBModel;
using PGDemo.DependencyInjection;

namespace PGDemo.Repository
{
    public interface IOrderDao : IBaseRepository<Order>, IDependency
    {
        IList<Order> Get(bool include);

        Task<List<Order>> GetAsync(bool include);

        Order Get(int id, bool include);

        Task<Order> GetAsync(int id, bool include);

        IList<Order> Get(Expression<Func<Order, bool>> whereExpression, bool include);

        Task<List<Order>> GetAsync(Expression<Func<Order, bool>> whereExpression, bool include);
    }
}
