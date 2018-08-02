using PGDemo.DependencyInjection;
using PGDemo.Model;
using System.Collections.Generic;

namespace PGDemo.Service
{
    public interface IProductService : IDependency
    {
        IEnumerable<ProductModel> GetProducts();

        ProductModel GetProduct(int id);

        bool InsertProduct(ProductModel model);

        bool UpdateProduct(ProductModel model);

        bool DeleteProduct(int id);
    }
}
