using PGDemo.DependencyInjection;
using PGDemo.Model;
using System.Collections.Generic;

namespace PGDemo.Repository
{
    public interface IProductDao : IDependency
    {
        IEnumerable<ProductModel> Get();

        ProductModel Get(int id);

        bool Insert(ProductModel model);

        bool Update(ProductModel model);

        bool Delete(int id);
    }
}
