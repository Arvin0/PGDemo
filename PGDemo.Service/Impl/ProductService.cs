using System;
using System.Collections.Generic;
using System.Text;
using PGDemo.Model;
using PGDemo.Repository;

namespace PGDemo.Service.Impl
{
    public class ProductService : IProductService
    {
        private readonly IProductDao _productDao;

        public ProductService(IProductDao productDao)
        {
            _productDao = productDao;
        }

        IEnumerable<ProductModel> IProductService.GetProducts()
        {
            return _productDao.Get();
        }

        public ProductModel GetProduct(int id)
        {
            return _productDao.Get(id);
        }

        public bool InsertProduct(ProductModel model)
        {
            return _productDao.Insert(model);
        }

        public bool UpdateProduct(ProductModel model)
        {
            return _productDao.Update(model);
        }

        public bool DeleteProduct(int id)
        {
            return _productDao.Delete(id);
        }
    }
}
