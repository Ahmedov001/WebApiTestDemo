using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTestDemo.Services;

namespace WebApiTestDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts(int top = 0)
        {
            var products = _productService.GetProducts(top);
            return Ok(products);
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Product>> GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public ActionResult<Product> Add(Product product)
        {
            var products = _productService.GetProducts();
            product.Id = products.Count() > 0 ? products.Max(p => p.Id) + 1 : 1;
            _productService.Add(product);
            return product;
        }
        [HttpPut]
        public ActionResult<Product> Update(Product product)
        {
            var updatedProduct = _productService.Update(product);
            return Ok(updatedProduct);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result  = _productService.Delete(id);
            if (!result) return BadRequest();
            return Ok();
        }
    }
}
