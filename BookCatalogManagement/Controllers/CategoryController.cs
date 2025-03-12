using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalBookstoreManagement.Services;
using DigitalBookstoreManagement.Models;

namespace DigitalBookstoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // Get all categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            return Ok(await _categoryService.GetAllCategoriesAsync());
        }

        // Get category by ID
        [HttpGet("{categoryId}")]
        public async Task<ActionResult<Category>> GetCategoryById(string categoryId)
        {
            var category = await _categoryService.GetCategoryByIdAsync(categoryId);
            if (category == null)
                return NotFound($"Category with ID {categoryId} not found.");

            return Ok(category);
        }

        // Add a new category
        [HttpPost]
        public async Task<ActionResult> AddCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _categoryService.AddCategoryAsync(category);
            return CreatedAtAction("GetCategoryById", new { categoryId = category.CategoryID }, category);
        }

        // Update a category
        [HttpPut("{categoryId}")]
        public async Task<ActionResult> UpdateCategory(string categoryId, [FromBody] Category category)
        {
            if (categoryId != category.CategoryID)
                return BadRequest("Category ID mismatch.");

            var updated = await _categoryService.GetCategoryByIdAsync(categoryId);
            if (updated == null)
                return NotFound($"Category with ID {categoryId} not found.");

            await _categoryService.UpdateCategoryAsync(category);
            return NoContent();
        }

        // Delete a category
        [HttpDelete("{categoryId}")]
        public async Task<ActionResult> DeleteCategory(string categoryId)
        {
            var deleted = await _categoryService.GetCategoryByIdAsync(categoryId);
            if (deleted == null)
                return NotFound($"Category with ID {categoryId} not found.");

            await _categoryService.DeleteCategoryAsync(categoryId);
            return NoContent();
        }
    }
}