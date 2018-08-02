using PGDemo.DependencyInjection;
using PGDemo.Model;
using System.Collections.Generic;

namespace PGDemo.Repository
{
    public interface IOrderDao : IDependency
    {
        IEnumerable<OrderViewModel> Get();

        OrderViewModel Get(int id);

        bool Insert(OrderViewModel model);

        bool Update(OrderViewModel model);

        bool Delete(int id);
    }
}
