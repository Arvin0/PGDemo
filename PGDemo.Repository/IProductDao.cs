using PGDemo.DependencyInjection;
using PGDemo.Model;
using System.Collections.Generic;

namespace PGDemo.Repository
{
    public interface IProductDao : IDependency
    {
        IEnumerable<Product> Get();

        Product Get(int id);

        bool Add(Product model);

        bool Modify(Product model);

        bool Remove(int id);

        object Test();
    }
}
