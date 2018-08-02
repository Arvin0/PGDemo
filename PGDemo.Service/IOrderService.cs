using PGDemo.DependencyInjection;
using PGDemo.Model;
using System.Collections.Generic;

namespace PGDemo.Service
{
    public interface IOrderService : IDependency
    {
        IEnumerable<OrderViewModel> GetOrders();

        OrderViewModel GetOrder(int id);

        bool InsertOrder(OrderViewModel model);

        bool UpdateOrder(OrderViewModel model);

        bool DeleteOrder(int id);
    }
}
