using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PGDemo.DBModel;
using PGDemo.DependencyInjection;

namespace PGDemo.Repository
{
    public interface IOrderDao : IBaseRepository<Order>, IDependency
    {
        IList<Order> Get(bool include);

        Order Get(int id, bool include);

        IList<Order> Get(Expression<Func<Order, bool>> whereExpression, bool include);
    }
}
