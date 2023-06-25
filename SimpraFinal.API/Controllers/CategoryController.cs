using AutoMapper;
using SimpraFinal.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using SimpraFinal.API.DTOs;
using SimpraFinal.Business;

namespace SimpraFinal.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    // GET: api/Categories
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(_mapper.Map<IEnumerable<CategoryDTO>>(categories));
    }

    // GET: api/Categories/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);

        if (category == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CategoryDTO>(category));
    }

    // POST: api/Categories
    [HttpPost]
    public async Task<ActionResult<CategoryDTO>> PostCategory(CategoryDTO categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        await _categoryService.CreateCategoryAsync(category);

        return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, _mapper.Map<CategoryDTO>(category));
    }

    // PUT: api/Categories/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategory(int id, CategoryDTO categoryDto)
    {
        if (id != categoryDto.Id)
        {
            return BadRequest();
        }

        var category = _mapper.Map<Category>(categoryDto);
        await _categoryService.UpdateCategoryAsync(category);

        return NoContent();
    }

    // DELETE: api/Categories/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }

        await _categoryService.DeleteCategoryAsync(id);
        
        return NoContent();
    }
}