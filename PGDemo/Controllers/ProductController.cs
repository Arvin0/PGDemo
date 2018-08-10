using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PGDemo.Common.Exceptions;
using PGDemo.Model;
using PGDemo.Service;
using System.Collections.Generic;

namespace PGDemo.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("[controller]")]
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
        public ActionResult<IEnumerable<ProductViewModel>> Get()
        {
            var testResult = _productService.Test();
            return new ActionResult<IEnumerable<ProductViewModel>>(_productService.GetProducts());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<ProductViewModel> Get(int id)
        {
            return new ActionResult<ProductViewModel>(_productService.GetProduct(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        // POST api/values
        [HttpPost]
        public void Post([FromBody] ProductViewModel model)
        {
            var result = _productService.InsertProduct(model);
            if (!result)
            {
                throw new BusinessLogicException("新增失败");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductViewModel model)
        {
            var result = _productService.UpdateProduct(model);
            if (!result)
            {
                throw new BusinessLogicException("更新失败");
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
                throw new BusinessLogicException("删除失败");
            }
        }
    }
}
