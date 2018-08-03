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

        IEnumerable<Product> IProductService.GetProducts()
        {
            return _productDao.Get();
        }

        public Product GetProduct(int id)
        {
            return _productDao.Get(id);
        }

        public bool InsertProduct(Product model)
        {
            return _productDao.Add(model);
        }

        public bool UpdateProduct(Product model)
        {
            return _productDao.Modify(model);
        }

        public bool DeleteProduct(int id)
        {
            return _productDao.Remove(id);
        }

        public object Test()
        {
            return _productDao.Test();
        }
    }
}
