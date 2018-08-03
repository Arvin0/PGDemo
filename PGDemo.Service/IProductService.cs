using PGDemo.DependencyInjection;
using PGDemo.Model;
using System.Collections.Generic;

namespace PGDemo.Service
{
    public interface IProductService : IDependency
    {
        IEnumerable<Product> GetProducts();

        Product GetProduct(int id);

        bool InsertProduct(Product model);

        bool UpdateProduct(Product model);

        bool DeleteProduct(int id);

        object Test();
    }
}
