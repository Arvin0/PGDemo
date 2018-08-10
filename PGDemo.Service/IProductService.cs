using PGDemo.DependencyInjection;
using PGDemo.Model;
using System.Collections.Generic;

namespace PGDemo.Service
{
    public interface IProductService : IDependency
    {
        IList<ProductViewModel> GetProducts();

        ProductViewModel GetProduct(int id);

        bool InsertProduct(ProductViewModel model);

        bool UpdateProduct(ProductViewModel model);

        bool DeleteProduct(int id);

        object Test();
    }
}
