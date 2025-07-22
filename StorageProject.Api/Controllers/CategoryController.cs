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
    }
}
