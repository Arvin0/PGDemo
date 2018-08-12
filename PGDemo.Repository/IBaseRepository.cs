using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PGDemo.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class, new ()
    {
        IList<TEntity> Get();

        Task<List<TEntity>> GetAsync();

        TEntity Get(int id);

        Task<TEntity> GetAsync(int id);

        IList<TEntity> Get(Expression<Func<TEntity, bool>> whereExpression);

        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> whereExpression);

        bool Add(TEntity model);

        bool AddAsync(TEntity model);

        bool Add(IList<TEntity> model);

        bool AddAsync(IList<TEntity> model);

        bool Modify(TEntity model);

        bool Remove(TEntity model);
    }
}
