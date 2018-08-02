using PGDemo.Model;
using PGDemo.Repository.EFCore.dbcontext;
using System.Collections.Generic;
using System.Linq;

namespace PGDemo.Repository.Impl
{
    public class ProductDao : IProductDao
    {
        private readonly ProductDbContext _productContext;

        public ProductDao(ProductDbContext productContext)
        {
            _productContext = productContext;
        }

        public IEnumerable<ProductModel> Get()
        {
            return _productContext.ProductModels.ToList();
        }

        public ProductModel Get(int id)
        {
            return _productContext.ProductModels.FirstOrDefault(product => product.Id == id);
        }

        public bool Insert(ProductModel model)
        {
            _productContext.ProductModels.Add(model);
            var result = _productContext.SaveChanges();
            return result > 0;
        }

        public bool Update(ProductModel model)
        {
            _productContext.ProductModels.Update(model);
            var result = _productContext.SaveChanges();
            return result > 0;
        }

        public bool Delete(int id)
        {
            var model = Get(id);
            _productContext.ProductModels.Remove(model);
            var result = _productContext.SaveChanges();
            return result > 0;
        }
    }
}
