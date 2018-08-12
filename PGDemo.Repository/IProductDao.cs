using PGDemo.DBModel;
using PGDemo.DependencyInjection;

namespace PGDemo.Repository
{
    public interface IProductDao : IBaseRepository<Product>, IDependency
    {
        object Test();
    }
}
