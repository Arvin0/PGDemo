using PGDemo.Model;
using PGDemo.Repository;
using System.Collections.Generic;

namespace PGDemo.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderDao _orderDao;

        public OrderService(IOrderDao orderDao)
        {
            _orderDao = orderDao;
        }

        public IEnumerable<OrderViewModel> GetOrders()
        {
            return _orderDao.Get();
        }

        public OrderViewModel GetOrder(int id)
        {
            return _orderDao.Get(id);
        }

        public bool InsertOrder(OrderViewModel model)
        {
            return _orderDao.Insert(model);
        }

        public bool UpdateOrder(OrderViewModel model)
        {
            return _orderDao.Update(model);
        }

        public bool DeleteOrder(int id)
        {
            return _orderDao.Delete(id);
        }
    }
}
