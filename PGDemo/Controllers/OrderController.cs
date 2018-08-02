using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PGDemo.Model;
using PGDemo.Service;

namespace PGDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<OrderViewModel>> Get()
        {
            return new ActionResult<IEnumerable<OrderViewModel>>(_orderService.GetOrders());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<OrderViewModel> Get(int id)
        {
            return new ActionResult<OrderViewModel>(_orderService.GetOrder(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] OrderViewModel model)
        {
            var result = _orderService.InsertOrder(model);
            if (!result)
            {
                throw new Exception("新增失败");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderViewModel model)
        {
            var result = _orderService.UpdateOrder(model);
            if (!result)
            {
                throw new Exception("更新失败");
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var result = _orderService.DeleteOrder(id);
            if (!result)
            {
                throw new Exception("删除失败");
            }
        }
    }
}
