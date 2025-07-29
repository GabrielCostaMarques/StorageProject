using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using StorageProject.Application.Contracts;
using StorageProject.Application.DTOs.Brand;
using StorageProject.Application.DTOs.Category;
using StorageProject.Application.Services;
using StorageProject.Application.Validators;

namespace StorageProject.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly CategoryValidator _categoryValidator;

        public CategoryController(ICategoryService categoryService, CategoryValidator categoryValidator)
        {
            _categoryService = categoryService;
            _categoryValidator = categoryValidator;
        }



        #region Get
        [HttpGet]
        [ProducesResponseType(typeof(CategoryDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var result = await _categoryService.GetAllAsync();

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }
        #endregion


        #region GetByID
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(CategoryDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _categoryService.GetByIdAsync(id);
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
        [ProducesResponseType(typeof(CategoryDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDTO createCategoryDTO)
        {
            try
            {
                var categoryValidator = await _categoryValidator.ValidateAsync(createCategoryDTO);

                if (!categoryValidator.IsValid)
                    return BadRequest(categoryValidator.ToDictionary());

                var result = await _categoryService.CreateAsync(createCategoryDTO);

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
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDTO updateCategoryDTO)
        {
            try
            {
                var categoryValidator = await _categoryValidator.ValidateAsync(updateCategoryDTO);

                if (!categoryValidator.IsValid)
                    return BadRequest(categoryValidator.ToDictionary());

                var result = await _categoryService.UpdateAsync(updateCategoryDTO);

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
            var result = await _categoryService.RemoveAsync(id);
            if (!result.IsSuccess)
            {
                return NotFound(result.Errors);
            }
            return Ok(result);
        }
        #endregion
    }
}
