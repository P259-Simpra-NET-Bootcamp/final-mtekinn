using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        return await _categoryRepository.GetByIdAsync(id);
    }

    public async Task<Category> GetCategoryWithProductsAsync(int id)
    {
        return await _categoryRepository.GetCategoryWithProductsAsync(id);
    }

    public async Task<List<Category>> GetAllWithProductsAsync()
    {
        return await _categoryRepository.GetAllWithProductsAsync();
    }

    public async Task<List<Category>> GetActiveCategoriesAsync()
    {
        return await _categoryRepository.GetActiveCategoriesAsync();
    }

    public async Task<Category> CreateCategoryAsync(Category category)
    {
        await _categoryRepository.CreateAsync(category);
        return category;
    }

    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        await _categoryRepository.UpdateAsync(category);
        return category;
    }

    public async Task DeleteCategoryAsync(int id)
    {
        await _categoryRepository.DeleteAsync(id);
    }
}