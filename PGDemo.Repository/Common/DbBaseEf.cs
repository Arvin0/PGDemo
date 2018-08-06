using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PGDemo.Repository.EFCore;

namespace PGDemo.Repository.Common
{
    public class DBBaseEF<T>  where T : class, new()
    {
        protected DbContext Db = DbContextFactory.Instance.GetDbContext<T>();

        #region Query

        public IEnumerable<T> Query()
        {
            return Db.Set<T>().ToList();
        }

        public T Query(dynamic id)
        {
            return Db.Set<T>().Find(id);
        }

        public T QueryFirstOrDefault(Expression<Func<T, bool>> whereExpression = null)
        {
            if (whereExpression != null)
            {
                return Db.Set<T>().FirstOrDefault(whereExpression);
            }

            return Db.Set<T>().FirstOrDefault();
        }

        #endregion

        #region Insert

        public int Insert(T model)
        {
            InsertWithoutSave(model);
            return Save();
        }

        public int Insert(IEnumerable<T> model)
        {
            InsertWithoutSave(model);
            return Save();
        }

        public void InsertWithoutSave(T model)
        {
            Db.Set<T>().Add(model);
        }

        public void InsertWithoutSave(IEnumerable<T> model)
        {
            Db.Set<T>().AddRange(model);
        }

        #endregion

        #region Update

        public int Update(T model)
        {
            UpdateWithoutSave(model);
            return Save();
        }

        public int Update(IEnumerable<T> model)
        {
            UpdateWithoutSave(model);
            return Save();
        }

        public void UpdateWithoutSave(T model)
        {
            var entry = Db.Entry(model);
            Db.Set<T>().Attach(model);
            entry.State = EntityState.Modified;
        }

        public void UpdateWithoutSave(IEnumerable<T> model)
        {
            Db.Set<T>().UpdateRange(model);
        }

        #endregion

        #region Delete

        public int Delete(T model)
        {
            DeleteWithoutSave(model);
            return Save();
        }

        public int Delete(IEnumerable<T> model)
        {
            DeleteWithoutSave(model);
            return Save();
        }

        public int Delete(Expression<Func<T, bool>> whereExpression)
        {
            var model = QueryFirstOrDefault(whereExpression);
            return Delete(model);
        }

        public int Delete(dynamic id)
        {
            var model = Query(id);
            return Delete(model);

        }
        public void DeleteWithoutSave(T model)
        {
            Db.Set<T>().Remove(model);
        }

        public void DeleteWithoutSave(IEnumerable<T> model)
        {
            Db.Set<T>().RemoveRange(model);
        }

        #endregion

        #region Save

        public int Save()
        {
            return Db.SaveChanges();
        }

        #endregion
    }
}
