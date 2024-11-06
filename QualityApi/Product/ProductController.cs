using Microsoft.AspNetCore.Mvc;
using QualityApi.Product.DTOs;

namespace QualityApi.Product{
    [ApiController]
    [Route("/products")]
    public class ProductController : ControllerBase{
        private readonly ProductService _productService;
        public ProductController(ProductService productService){
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto data){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var newProduct = await _productService.CreateProductAsync(data);
            return StatusCode(201, newProduct);
        }
    }
}