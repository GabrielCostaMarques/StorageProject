using Ardalis.Result;
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

        #region Get
        [HttpGet]
        [ProducesResponseType(typeof(BrandDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var result = await _brandService.GetAllAsync();

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }
        #endregion


        #region GetByID
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(BrandDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _brandService.GetByIdAsync(id);
                if (result.IsError())
                {
                    return NotFound(result.Errors);
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred." });
            }
        }
        #endregion


        #region Create   
        [HttpPost]
        [ProducesResponseType(typeof(BrandDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
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
        #endregion


        #region Update
        [HttpPut]
        [ProducesResponseType(typeof(Result), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] UpdateBrandDTO updateBrandDTO)
        {
            try
            {
                var brandValidator = await _brandValidator.ValidateAsync(updateBrandDTO);

                if (!brandValidator.IsValid)
                    return BadRequest(brandValidator.ToDictionary());

                var result = await _brandService.UpdateAsync(updateBrandDTO);

                if (result.IsConflict())
                    return Conflict(result);
                if (!result.IsSuccess)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred." });
            }

        }
        #endregion

        #region Delete
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
        #endregion
    }
}
