using PGDemo.Common.Exceptions;
using PGDemo.Model;
using PGDemo.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PGDemo.DBModel;

namespace PGDemo.Service.Impl
{
    public class ProductService : IProductService
    {
        private readonly IProductDao _productDao;

        public ProductService(IProductDao productDao)
        {
            _productDao = productDao;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            IList<ProductViewModel> productModels = null;

            var products = await _productDao.GetAsync();
            if (products != null)
            {
                var productQuery = from p in products
                    select new ProductViewModel()
                    {
                        Id = p.Id,
                        Category = p.Category,
                        CategoryB = p.CategoryB,
                        Description = p.Description,
                        Name = p.Name,
                        Price = p.Price
                    };

                productModels = productQuery.ToList();
            }

            return productModels;
        }

        public async Task<ProductViewModel> GetProduct(int id)
        {
            ProductViewModel productModel = null;
            var product = await _productDao.GetAsync(id);
            if (product != null)
            {
                productModel = new ProductViewModel
                {
                    Id = product.Id,
                    Category = product.Category,
                    CategoryB = product.CategoryB,
                    Description = product.Description,
                    Name = product.Name,
                    Price = product.Price
                };
            }

            return productModel;
        }

        public bool InsertProduct(ProductViewModel model)
        {
            var product = new Product()
            {
                Category = model.Category,
                CategoryB = model.CategoryB,
                Description = model.Description,
                Name = model.Name,
                Price = model.Price
            };
            return _productDao.Add(product);
        }

        public bool UpdateProduct(ProductViewModel model)
        {
            var product = _productDao.Get(model.Id);
            if (product == null)
            {
                throw new BusinessLogicException("该产品不存在");
            }

            product.Category = model.Category;
            product.CategoryB = model.CategoryB;
            product.Description = model.Description;
            product.Name = model.Name;
            product.Price = model.Price;

            return _productDao.Modify(product);
        }

        public bool DeleteProduct(int id)
        {
            var product = _productDao.Get(id);
            if (product == null)
            {
                throw new BusinessLogicException("该产品不存在");
            }

            return _productDao.Remove(product);
        }

        public object Test()
        {
            return _productDao.Test();
        }
    }
}
