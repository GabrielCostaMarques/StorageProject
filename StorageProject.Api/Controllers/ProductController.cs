using Microsoft.AspNetCore.Mvc;
using StorageProject.Domain.Contracts;
using System.Linq;

namespace StorageProject.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var product = await _productRepository.GetAllAsync();

            if (!product.Any())
            {
                return NotFound();
            }

            return  Ok(product);
        }
    }
}
