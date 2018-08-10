using PGDemo.DBModel;

namespace PGDemo.Repository
{
    public interface IProductDao : IBaseRepository<Product>
    {
        object Test();
    }
}
