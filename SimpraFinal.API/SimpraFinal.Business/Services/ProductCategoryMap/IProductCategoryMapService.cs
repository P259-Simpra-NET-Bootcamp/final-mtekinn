using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public interface IProductCategoryMapService
{
    Task<IEnumerable<ProductCategoryMap>> GetAllAsync();
    Task<ProductCategoryMap> GetByIdAsync(int id);
    Task CreateAsync(ProductCategoryMap productCategoryMap);
    Task UpdateAsync(ProductCategoryMap productCategoryMap);
    Task DeleteAsync(int id);
    Task<List<ProductCategoryMap>> GetByProductIdAsync(int productId);
    Task<List<ProductCategoryMap>> GetByCategoryIdAsync(int categoryId);
    Task DeleteByProductIdAsync(int productId);
    Task DeleteByCategoryIdAsync(int categoryId);
}