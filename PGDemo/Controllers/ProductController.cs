using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PGDemo.Model;
using PGDemo.Service;

namespace PGDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> Get()
        {
            return new ActionResult<IEnumerable<ProductModel>>(_productService.GetProducts());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<ProductModel> Get(int id)
        {
            return new ActionResult<ProductModel>(_productService.GetProduct(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] ProductModel model)
        {
            var result = _productService.InsertProduct(model);
            if (!result)
            {
                throw new Exception("新增失败");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductModel model)
        {
            var result = _productService.UpdateProduct(model);
            if (!result)
            {
                throw new Exception("更新失败");
            }
        }

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
