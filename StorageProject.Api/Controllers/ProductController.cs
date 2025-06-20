using Microsoft.AspNetCore.Mvc;
using StorageProject.Application.Contracts;
using StorageProject.Application.DTOs;

namespace StorageProject.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var product = await _productService.GetAllAsync();

            if (!product.Any())
            {
                return NotFound();
            }

            return  Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDTO productDTO)
        {
            var product = await _productService.CreateAsync(productDTO);
            return Ok(product);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productService.RemoveAsync(id);
            return Ok();
        }
    }
}
