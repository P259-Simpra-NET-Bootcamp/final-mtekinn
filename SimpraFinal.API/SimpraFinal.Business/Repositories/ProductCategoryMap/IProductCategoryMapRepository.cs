using SimpraFinal.Business.Interfaces.BaseRepository;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public interface IProductCategoryMapRepository : IGenericRepository<ProductCategoryMap>
{
    Task<IEnumerable<ProductCategoryMap>> GetByProductIdAsync(int productId);
    Task<IEnumerable<ProductCategoryMap>> GetByCategoryIdAsync(int categoryId);
    Task DeleteByProductIdAsync(int productId);
    Task DeleteByCategoryIdAsync(int categoryId);
    Task DeleteAsync(int id);
    Task<IEnumerable<ProductCategoryMap>> GetAllProductCategoryMapsAsync();
}