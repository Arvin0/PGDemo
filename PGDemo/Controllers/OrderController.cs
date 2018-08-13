using Microsoft.AspNetCore.Mvc;
using PGDemo.ApiCore.Common;
using PGDemo.ApiCore.Model;
using PGDemo.Model;
using PGDemo.Service;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PGDemo.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("[controller]")]
    public class OrderController : ApiController
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
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(IEnumerable<OrderViewModel>))]
        public async Task<ApiResponse> Get()
        {
            return Success(await _orderService.GetOrders());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(OrderViewModel))]
        public async Task<ApiResponse> Get(int id)
        {
            return Success(await _orderService.GetOrder(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        // POST api/values
        [HttpPost]
        public ApiResponse Post([FromBody] OrderViewModel model)
        {
            var result = _orderService.InsertOrder(model);

            if (!result)
            {
                return Failture(0, "新增失败");
            }

            return Success();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        // PUT api/values/5
        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] OrderViewModel model)
        {
            var result = _orderService.UpdateOrder(model);
            if (!result)
            {
                return Failture(0, "更新失败");
            }

            return Success();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            var result = _orderService.DeleteOrder(id);
            if (!result)
            {
                return Failture(0, "删除失败");
            }

            return Success();
        }
    }
}
