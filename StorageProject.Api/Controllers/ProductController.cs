using Microsoft.AspNetCore.Mvc;
using StorageProject.Domain.Repositories.Contracts;
using System.Linq;

namespace StorageProject.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {

        private readonly IProductRepository _productRepository;
        public async Task<IActionResult> GetAll()
        {
            var product = await _productRepository.GetAllAsync();

            if ()
            {
                return NotFound();
            }

            return  Ok(product);
        }
    }
}
