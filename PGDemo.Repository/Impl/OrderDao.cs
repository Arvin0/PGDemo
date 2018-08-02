using Microsoft.EntityFrameworkCore.Internal;
using PGDemo.Model;
using PGDemo.Repository.EFCore.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PGDemo.Repository.Impl
{
    public class OrderDao : IOrderDao
    {
        private readonly ProductDbContext _productContext;
        private readonly OrderDbContext _orderContext;

        public OrderDao(ProductDbContext productContext, OrderDbContext orderContext)
        {
            _productContext = productContext;
            _orderContext = orderContext;
        }

        public IEnumerable<OrderViewModel> Get()
        {
            IList<OrderViewModel> orderModels = new List<OrderViewModel>();

            var orders = _orderContext.Order.ToList();
            if (orders.Any())
            {
                foreach (var order in orders)
                {
                    var orderModel = new OrderViewModel();
                    orderModel.Id = order.Id;
                    orderModel.Title = order.Title;
                    orderModel.CreateTime = order.CreateTime;
                    orderModel.TotalPrice = order.TotalPrice;
                    orderModel.TotalAmount = order.TotalAmount;

                    //联合查询
                    var orderItemModelQuery = _orderContext.OrderItems
                        .Join(_orderContext.Product, item => item.ProductId, pro => pro.Id,
                            (item, pro) => new OrderItemViewModel()
                            {
                                Id = item.Id,
                                OrderId = item.OrderId,
                                Price = item.Price,
                                ProductId = item.ProductId,
                                ProductName = pro.Name
                            })
                        .Where(item => item.OrderId == orderModel.Id)
                        .OrderBy(item => item.Id);

                    orderModel.OrderItems = orderItemModelQuery.ToList();

                    orderModels.Add(orderModel);
                }
            }

            return orderModels;
        }

        public OrderViewModel Get(int id)
        {
            OrderViewModel orderModel = null;

            var order = _orderContext.Order.FirstOrDefault(o => o.Id == id);
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

                //联合查询
                var orderItemModelQuery = _orderContext.OrderItems
                    .Join(_orderContext.Product, item => item.ProductId, pro => pro.Id,
                        (item, pro) => new OrderItemViewModel()
                        {
                            Id = item.Id,
                            OrderId = item.OrderId,
                            Price = item.Price,
                            ProductId = item.ProductId,
                            ProductName = pro.Name
                        })
                    .Where(item => item.OrderId == orderModel.Id)
                    .OrderBy(item => item.Id);
                orderModel.OrderItems = orderItemModelQuery.ToList();
            }

            return orderModel;
        }

        public bool Insert(OrderViewModel model)
        {
            var dbOrder = new OrderModel
            {
                Id = model.Id,
                Title = model.Title,
                CreateTime = DateTime.Now,
            };

            IList<OrderItemModel> itemsModels = new List<OrderItemModel>();
            foreach (var item in model.OrderItems)
            {
                var product = _productContext.ProductModels.FirstOrDefault(p => p.Id == item.ProductId);
                itemsModels.Add(new OrderItemModel()
                {
                    Id = item.Id,
                    OrderId = model.Id,
                    ProductId = item.ProductId,
                    Price = product.Price
                });
            }

            dbOrder.TotalAmount = itemsModels.Count;
            dbOrder.TotalPrice = itemsModels.Sum(item => item.Price);

            #region 主、副表插入时，使用事务；先更新主表获取主表ID，再填充外键字段并更新副表

            int result = 0;
            using (var transaction = _orderContext.Database.BeginTransaction())
            {
                try
                {
                    _orderContext.Order.Add(dbOrder);
                    _orderContext.SaveChanges();

                    itemsModels.ToList().ForEach(i => i.OrderId = dbOrder.Id);
                    _orderContext.OrderItems.AddRange(itemsModels);
                    result = _orderContext.SaveChanges();

                    if (result <= 0)
                    {
                        transaction.Rollback();
                    }

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            #endregion

            return result > 0;
        }

        public bool Update(OrderViewModel model)
        {
            var dbOrder = _orderContext.Order.FirstOrDefault(o => o.Id == model.Id);
            if (dbOrder != null)
            {
                dbOrder.Title = model.Title;
                dbOrder.TotalAmount = model.OrderItems.Count;
                dbOrder.TotalPrice = model.OrderItems.Sum(item => item.Price);
            }

            IList<OrderItemModel> itemModels = _orderContext.OrderItems
                .Where(item => model.OrderItems.FirstOrDefault(i => i.Id == item.Id) != null)
                .ToList();
            foreach (var itemModel in itemModels)
            {
                var item = model.OrderItems.FirstOrDefault(i => i.Id == itemModel.Id);
                itemModel.Price = item.Price;
            }

            _orderContext.Order.Update(dbOrder);
            _orderContext.OrderItems.UpdateRange(itemModels);

            var result = _orderContext.SaveChanges();
            return result > 0;
        }

        public bool Delete(int id)
        {
            var dbOrder = _orderContext.Order.FirstOrDefault(o => o.Id == id);

            IList<OrderItemModel> itemModels = _orderContext.OrderItems
                .Where(item => item.OrderId == id)
                .ToList();

            _orderContext.Order.Remove(dbOrder);
            _orderContext.OrderItems.RemoveRange(itemModels);

            var result = _orderContext.SaveChanges();
            return result > 0;
        }
    }
}
