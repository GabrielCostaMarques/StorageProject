using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using StorageProject.Application.Contracts;
using StorageProject.Application.DTOs.Product;

namespace StorageProject.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
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

            return  Ok(product);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product.IsNotFound())
            {
                return NotFound(product);
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDTO createProductDTO)
        {
            await _productService.CreateAsync(createProductDTO);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductDTO updateProductDTO)
        {
            await _productService.UpdateAsync(updateProductDTO);
            return Ok();
        }


        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productService.RemoveAsync(id);
            return Ok();
        }
    }
}
