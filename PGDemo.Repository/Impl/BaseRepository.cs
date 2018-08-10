using PGDemo.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PGDemo.Repository.Impl
{
    public class BaseRepository<TEntity> : DbBaseEF<TEntity>, IBaseRepository<TEntity> where TEntity : class , new ()
    {
        public IList<TEntity> Get()
        {
            return Query().ToList();
        }

        public TEntity Get(int id)
        {
            return Query(id);
        }

        public IList<TEntity> Get(Expression<Func<TEntity, bool>> whereExpression)
        {
            return Query(whereExpression).ToList();
        }

        public bool Add(TEntity model)
        {
            return Insert(model) > 0;
        }

        public bool Modify(TEntity model)
        {
            return Update(model) > 0;
        }

        public bool Remove(TEntity model)
        {
            // 如果设置级联删除，子项也会被删除
            return Delete(model) > 0;
        }
    }
}
