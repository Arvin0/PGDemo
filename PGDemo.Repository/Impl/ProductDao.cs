using Microsoft.EntityFrameworkCore;
using PGDemo.Model;
using PGDemo.Repository.Common;
using PGDemo.Repository.EFCore.dbcontext;
using System;
using System.Collections.Generic;

namespace PGDemo.Repository.Impl
{
    public class ProductDao : DBBaseEF<Product>, IProductDao
    {
        private readonly ProductDbContext _productContext;

        public ProductDao()
        {
            _productContext = (ProductDbContext)Db;
        }

        public IEnumerable<Product> Get()
        {
            return Query();
        }

        public Product Get(int id)
        {
            return QueryFirstOrDefault(p => p.Id == id);
        }

        public bool Add(Product model)
        {
            return Insert(model) > 0;
        }

        public bool Modify(Product model)
        {
            var oldValue = Get(model.Id);
            _productContext.Entry(oldValue).CurrentValues.SetValues(model);
            return _productContext.SaveChanges() >= 0;
        }

        public bool Remove(int id)
        {
            return Delete(id) > 0;
        }

        public object Test()
        {
            ////Query

            //var query = _productContext.ProductModels.FromSql("select * from product;");

            //var query = _productContext.ProductModels.FromSql("select * from product where id = @id;", 
            //    new []
            //    {
            //        new NpgsqlParameter("@id", 2)
            //    });

            //var query = _productContext.ProductModels.FromSql(
            //    @"select * from product where (category->>'First') = '水果';");

            //return query.ToList();

            ////Update

            var update = _productContext.Database.ExecuteSqlCommand(
                $"update product set description = '{DateTime.Now}' where (category->>'First') = '水果';");

            return update;
        }
    }
}
