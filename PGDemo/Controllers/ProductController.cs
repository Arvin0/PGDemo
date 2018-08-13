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
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productService"></param>
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(IEnumerable<ProductViewModel>))]
        public async Task<ApiResponse> Get()
        {
            //var testResult = _productService.Test();
            return  Success(await _productService.GetProducts());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(ProductViewModel))]
        public async Task<ApiResponse> Get(int id)
        {
            return Success(await _productService.GetProduct(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        // POST api/values
        [HttpPost]
        public ApiResponse Post([FromBody] ProductViewModel model)
        {
            var result = _productService.InsertProduct(model);
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
        public ApiResponse Put(int id, [FromBody] ProductViewModel model)
        {
            var result = _productService.UpdateProduct(model);
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
            var result = _productService.DeleteProduct(id);
            if (!result)
            {
                return Failture(0, "删除失败");
            }

            return Success();
        }
    }
}
