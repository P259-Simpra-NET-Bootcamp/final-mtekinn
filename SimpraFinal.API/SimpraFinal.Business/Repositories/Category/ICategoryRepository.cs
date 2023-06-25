using SimpraFinal.Business.Interfaces.BaseRepository;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<Category> GetCategoryWithProductsAsync(int id);
    Task<List<Category>> GetAllWithProductsAsync();
    Task<List<Category>> GetActiveCategoriesAsync();
}