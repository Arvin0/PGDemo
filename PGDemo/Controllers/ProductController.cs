using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PGDemo.Model;
using PGDemo.Service;
using System;
using System.Collections.Generic;

namespace PGDemo.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
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
        public ActionResult<IEnumerable<Product>> Get()
        {
            var testResult = _productService.Test();
            return new ActionResult<IEnumerable<Product>>(_productService.GetProducts());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return new ActionResult<Product>(_productService.GetProduct(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        // POST api/values
        [HttpPost]
        public void Post([FromBody] Product model)
        {
            var result = _productService.InsertProduct(model);
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
        public void Put(int id, [FromBody] Product model)
        {
            var result = _productService.UpdateProduct(model);
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
            var result = _productService.DeleteProduct(id);
            if (!result)
            {
                throw new Exception("删除失败");
            }
        }
    }
}
