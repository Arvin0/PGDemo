using Microsoft.EntityFrameworkCore;
using PGDemo.DBModel;
using System;

namespace PGDemo.Repository.Impl
{
    public class ProductDao : BaseRepository<Product>, IProductDao
    {
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

            var update = DbContext.Database.ExecuteSqlCommand(
                $"update product set description = '{DateTime.Now}' where (category->>'First') = '水果';");

            return update;
        }
    }
}
 