using PGDemo.Common.Exceptions;
using PGDemo.Model;
using PGDemo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using PGDemo.DBModel;

namespace PGDemo.Service.Impl
{
    public class OrderService : IOrderService
    {
        private readonly IOrderDao _orderDao;
        private readonly IProductDao _productDao;

        public OrderService(IOrderDao orderDao, IProductDao productDao)
        {
            _orderDao = orderDao;
            _productDao = productDao;
        }

        public IEnumerable<OrderViewModel> GetOrders()
        {
            var orderModels = new List<OrderViewModel>();

            var orders = _orderDao.Get();
            if (orders.Any())
            {
                foreach (var order in orders)
                {
                    var orderModel = new OrderViewModel
                    {
                        Id = order.Id,
                        Title = order.Title,
                        CreateTime = order.CreateTime,
                        TotalPrice = order.TotalPrice,
                        TotalAmount = order.TotalAmount
                    };

                    //获取订单明细
                    var orderItemViewModel = from item in order.OrderItems
                        select new OrderItemViewModel
                        {
                            Id = item.Id,
                            OrderId = item.OrderId,
                            Price = item.Price,
                            ProductId = item.ProductId,
                            ProductName = item.Product.Name
                        };

                    orderModel.OrderItems = orderItemViewModel.ToList();

                    orderModels.Add(orderModel);
                }
            }

            return orderModels;
        }

        public OrderViewModel GetOrder(int id)
        {
            OrderViewModel orderModel = null;

            var order = _orderDao.Get(id);
            if (order != null)
            {
                orderModel = new OrderViewModel
                {
                    Id = order.Id,
                    Title = order.Title,
                    CreateTime = order.CreateTime,
                    TotalPrice = order.TotalPrice,
                    TotalAmount = order.TotalAmount
                };

                //获取订单明细
                var orderItemViewModel = from item in order.OrderItems
                    select new OrderItemViewModel
                    {
                        Id = item.Id,
                        OrderId = item.OrderId,
                        Price = item.Price,
                        ProductId = item.ProductId,
                        ProductName = item.Product.Name
                    };

                orderModel.OrderItems = orderItemViewModel.ToList();
            }

            return orderModel;
        }

        public bool InsertOrder(OrderViewModel model)
        {
            var productIds = model.OrderItems.Select(item => item.Id).ToList();
            var products = _productDao.Get(p => productIds.Contains(p.Id));
            var itemsModels = (from item in model.OrderItems
                let product = products.FirstOrDefault(p => p.Id == item.ProductId)
                select new OrderItem()
                {
                    Id = item.Id,
                    OrderId = model.Id,
                    ProductId = item.ProductId,
                    Price = product.Price
                }).ToList();

            var order = new Order
            {
                Id = model.Id,
                Title = model.Title,
                CreateTime = DateTime.Now,
                TotalAmount = itemsModels.Count,
                TotalPrice = itemsModels.Sum(item => item.Price),

                OrderItems = itemsModels
            };

            return _orderDao.Add(order);
        }

        public bool UpdateOrder(OrderViewModel model)
        {
            var order = _orderDao.Get(model.Id);
            if (order == null)
            {
                throw new BusinessLogicException("该订单不存在");
            }

            order.Title = model.Title;
            order.TotalAmount = model.OrderItems.Count;
            order.TotalPrice = model.OrderItems.Sum(item => item.Price);

            foreach (var itemModel in model.OrderItems)
            {
                var item = model.OrderItems.FirstOrDefault(i => i.Id == itemModel.Id);
                if (item == null)
                {
                    throw new BusinessLogicException($"该订单明细 [{itemModel.Id}] 不存在");
                }
                itemModel.Price = item.Price;
            }

            return _orderDao.Modify(order);
        }

        public bool DeleteOrder(int id)
        {
            var order = _orderDao.Get(id);
            if (order == null)
            {
                throw new BusinessLogicException("该订单不存在");
            }

            return _orderDao.Remove(order);
        }
    }
}
