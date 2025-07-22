using Microsoft.AspNetCore.Mvc;
using StorageProject.Application.Contracts;
using StorageProject.Application.DTOs.Brand;

namespace StorageProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var brand = await _brandService.GetAllAsync();

            if (!brand.Any())
            {
                return NotFound();
            }

            return Ok(brand);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BrandDTO brandDTO)
        {
            var brand = await _brandService.CreateAsync(brandDTO);
            return Ok(brand);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBrandDTO changeBrandDTO)
        {
            var updatedBrand = await _brandService.UpdateAsync(changeBrandDTO);
            return Ok(updatedBrand);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _brandService.RemoveAsync(id);
            if (!result.IsSuccess)
            {
                return NotFound(result.Errors);
            }
            return Ok(result);
        }
    }
}
