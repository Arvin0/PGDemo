using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PGDemo.DependencyInjection;

namespace PGDemo.Repository
{
    public interface IBaseRepository<TEntity> : IDependency where TEntity : class, new ()
    {
        IList<TEntity> Get();

        TEntity Get(int id);

        IList<TEntity> Get(Expression<Func<TEntity, bool>> whereExpression);

        bool Add(TEntity model);

        bool Modify(TEntity model);

        bool Remove(TEntity model);
    }
}
