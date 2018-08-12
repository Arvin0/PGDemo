using PGDemo.DependencyInjection;
using PGDemo.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PGDemo.Service
{
    public interface IProductService : IDependency
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();

        Task<ProductViewModel> GetProduct(int id);

        bool InsertProduct(ProductViewModel model);

        bool UpdateProduct(ProductViewModel model);

        bool DeleteProduct(int id);

        object Test();
    }
}
