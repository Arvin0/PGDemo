using PGDemo.DependencyInjection.IocFlag;
using PGDemo.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PGDemo.Service
{
    public interface IOrderService : IDependency
    {
        Task<IEnumerable<OrderViewModel>> GetOrders();

        Task<OrderViewModel> GetOrder(int id);

        bool InsertOrder(OrderViewModel model);

        bool UpdateOrder(OrderViewModel model);

        bool DeleteOrder(int id);
    }
}
