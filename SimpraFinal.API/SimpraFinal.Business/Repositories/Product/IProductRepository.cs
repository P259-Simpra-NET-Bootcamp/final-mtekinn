using SimpraFinal.Business.Interfaces.BaseRepository;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;
public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsWithCategoriesAsync();
    Task<IEnumerable<Product>> GetActiveProductsWithCategoriesAsync();
    Task<Product> GetProductByIdWithCategoryAsync(int productId);
    Task<Product> GetProductWithCategoriesByIdAsync(int id);
    Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId);
    Task<bool> IsProductAvailableAsync(int productId, int quantity);
}