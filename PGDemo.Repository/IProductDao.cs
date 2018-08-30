using PGDemo.DBModel;
using PGDemo.DependencyInjection.IocFlag;

namespace PGDemo.Repository
{
    public interface IProductDao : IBaseRepository<Product>, IDependency
    {
        object Test();
    }
}
