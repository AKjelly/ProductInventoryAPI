using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductInventoryAPI.Model;
using ProductInventoryAPI.Services;

namespace ProductInventoryAPI.Controllers
{
   
    
    public class ProductsController : ControllerBase
    {
        private readonly ProductServices _productsService;

        public ProductsController(ProductServices productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAll()
        {
            return Ok(_productsService.GetAll());
        }
        [HttpPost("AddProduct")]
        public IActionResult Create(Product product )
        {
            _productsService.Add(product);
            return Ok(product);
        }

        [HttpPut("UpdateProduct")]
        public IActionResult Update([FromBody] Product product)
        {
            _productsService.Update(product);
            return Ok(product);
        }
        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult Delete(int id)
        {
            _productsService.Delete(id);
            return Ok(new {message ="Product Deleted",id=id});
        }
        [HttpGet("GetProductById/{id}")]
        public IActionResult GetProductById(int id)
        {
            var product=_productsService.GetById(id);
            if(product == null)return Ok(new { message = "Product Id Not Found" });
            return Ok(product);
        }
    }
}
