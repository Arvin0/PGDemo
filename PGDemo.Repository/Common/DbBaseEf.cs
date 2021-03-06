﻿using PGDemo.Repository.EFCore.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PGDemo.Repository.Common
{
    public class DbBaseEF<TEntity> where TEntity : class, new()
    {
        protected readonly PGDemoDbContext DbContext;

        #region Constructor

        public DbBaseEF(PGDemoDbContext dbContext)
        {
            DbContext = dbContext;
        }

        #endregion

        #region Query

        public IEnumerable<TEntity> Query()
        {
            return DbContext.Set<TEntity>().ToList();
        }

        public Task<List<TEntity>> QueryAsync()
        {
            return DbContext.Set<TEntity>().ToListAsync();
        }

        public IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> whereExpression)
        {
            return DbContext.Set<TEntity>().Where(whereExpression);
        }

        public Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> whereExpression)
        {
            return DbContext.Set<TEntity>().Where(whereExpression).ToListAsync();
        }

        public TEntity Query(dynamic id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public Task<TEntity> QueryAsync(dynamic id)
        {
            return DbContext.Set<TEntity>().FindAsync(id);
        }

        public TEntity QueryFirstOrDefault(Expression<Func<TEntity, bool>> whereExpression)
        {
            return DbContext.Set<TEntity>().FirstOrDefault(whereExpression);
        }

        public Task<TEntity> QueryFirstOrDefaultAsync(Expression<Func<TEntity, bool>> whereExpression)
        {
            return DbContext.Set<TEntity>().FirstOrDefaultAsync(whereExpression);
        }

        #endregion

        #region Insert

        public int Insert(TEntity model)
        {
            InsertWithoutSave(model);
            return Save();
        }

        public Task<int> InsertAsync(TEntity model)
        {
            InsertWithoutSaveAsync(model);
            return SaveAsync();
        }

        public int Insert(IEnumerable<TEntity> model)
        {
            InsertWithoutSave(model);
            return Save();
        }

        public Task<int> InsertAsync(IEnumerable<TEntity> model)
        {
            InsertWithoutSaveAsync(model);
            return SaveAsync();
        }

        public void InsertWithoutSave(TEntity model)
        {
            DbContext.Set<TEntity>().Add(model);
        }

        public void InsertWithoutSaveAsync(TEntity model)
        {
            DbContext.Set<TEntity>().AddAsync(model);
        }

        public void InsertWithoutSave(IEnumerable<TEntity> model)
        {
            DbContext.Set<TEntity>().AddRange(model);
        }

        public void InsertWithoutSaveAsync(IEnumerable<TEntity> model)
        {
            DbContext.Set<TEntity>().AddRangeAsync(model);
        }

        #endregion

        #region Update

        public int Update(TEntity model)
        {
            UpdateWithoutSave(model);
            return Save();
        }

        public int Update(IEnumerable<TEntity> model)
        {
            UpdateWithoutSave(model);
            return Save();
        }

        public void UpdateWithoutSave(TEntity model)
        {
            DbContext.Set<TEntity>().Update(model);
        }

        public void UpdateWithoutSave(IEnumerable<TEntity> model)
        {
            DbContext.Set<TEntity>().UpdateRange(model);
        }

        #endregion

        #region Delete

        public int Delete(TEntity model)
        {
            DeleteWithoutSave(model);
            return Save();
        }

        public int Delete(IEnumerable<TEntity> model)
        {
            DeleteWithoutSave(model);
            return Save();
        }

        public int Delete(Expression<Func<TEntity, bool>> whereExpression)
        {
            var model = QueryFirstOrDefault(whereExpression);
            return Delete(model);
        }

        public int Delete(dynamic id)
        {
            var model = Query(id);
            return Delete(model);

        }
        public void DeleteWithoutSave(TEntity model)
        {
            DbContext.Set<TEntity>().Remove(model);
        }

        public void DeleteWithoutSave(IEnumerable<TEntity> model)
        {
            DbContext.Set<TEntity>().RemoveRange(model);
        }

        #endregion

        #region Save

        public int Save()
        {
            return DbContext.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return DbContext.SaveChangesAsync();
        }

        #endregion
    }
}
