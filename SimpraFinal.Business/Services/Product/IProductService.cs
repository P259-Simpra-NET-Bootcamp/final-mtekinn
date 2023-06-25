using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public interface IProductService
{
    Task<List<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task<Product> CreateProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product product);
    Task DeleteProductAsync(int id);
    Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId);
    Task<bool> IsProductAvailableAsync(int productId, int quantity);
}