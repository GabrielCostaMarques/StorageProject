using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StorageProject.Application.Contracts;
using StorageProject.Application.DTOs.Brand;
using StorageProject.Application.Validators;

namespace StorageProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly BrandValidator _brandValidator;


        public BrandController(IBrandService brandService, BrandValidator brandValidator)
        {
            _brandService = brandService;
            _brandValidator = brandValidator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var brand = await _brandService.GetAllAsync();

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
            try
            {
                var brandValidator = await _brandValidator.ValidateAsync(createBrandDTO);

                if (!brandValidator.IsValid)
                    return BadRequest(brandValidator.ToDictionary());

                var result = await _brandService.CreateAsync(createBrandDTO);

                if (result.IsConflict())
                    return Conflict(result);
                if (!result.IsSuccess)
                    return BadRequest(result);

                return CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred." });
            }
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
