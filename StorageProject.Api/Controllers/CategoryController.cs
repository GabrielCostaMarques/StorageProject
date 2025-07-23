using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using StorageProject.Application.Contracts;
using StorageProject.Application.DTOs.Category;

namespace StorageProject.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var category = await _categoryService.GetAllAsync();

            if (!category.Any())
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryDTO categoryDTO)
        {
            var category = await _categoryService.CreateAsync(categoryDTO);
            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category.IsError())
            {
                return NotFound(category.Errors);
            }
            return Ok(category);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDTO updateCategoryDTO)
        {
            var result = await _categoryService.UpdateAsync(updateCategoryDTO);
            if (result.IsError())
            {
                return NotFound(result.Errors);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _categoryService.RemoveAsync(id);
            if (result.IsError())
            {
                return NotFound(result.Errors);
            }
            return Ok(result);
        }
    }
}
