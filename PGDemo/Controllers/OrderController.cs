using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PGDemo.Model;
using PGDemo.Service;

namespace PGDemo.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderService"></param>
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<OrderViewModel>> Get()
        {
            return new ActionResult<IEnumerable<OrderViewModel>>(_orderService.GetOrders());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<OrderViewModel> Get(int id)
        {
            return new ActionResult<OrderViewModel>(_orderService.GetOrder(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
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
