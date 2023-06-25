using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public interface ICategoryService
{
    Task<List<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int id);
    Task<Category> GetCategoryWithProductsAsync(int id);
    Task<List<Category>> GetAllWithProductsAsync();
    Task<List<Category>> GetActiveCategoriesAsync();
    Task<Category> CreateCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(int id);
}