using Ardalis.Result;
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

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var brand = await _brandService.GetByIdAsync(id);
            if (brand.IsError())
            {
                return NotFound(brand.Errors);
            }
            return Ok(brand);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBrandDTO createBrandDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brand = await _brandService.CreateAsync(createBrandDTO);
            return Ok(brand);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBrandDTO updateBrandDTO)
        {
            var updatedBrand = await _brandService.UpdateAsync(updateBrandDTO);
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
