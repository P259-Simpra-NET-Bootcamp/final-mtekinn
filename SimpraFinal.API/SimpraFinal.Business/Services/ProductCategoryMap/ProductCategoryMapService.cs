using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public class ProductCategoryMapService : IProductCategoryMapService
{
    private readonly IProductCategoryMapRepository _productCategoryMapRepository;

    public ProductCategoryMapService(IProductCategoryMapRepository productCategoryMapRepository)
    {
        _productCategoryMapRepository = productCategoryMapRepository;
    }

    public async Task<IEnumerable<ProductCategoryMap>> GetAllAsync()
    {
        return await _productCategoryMapRepository.GetAllAsync();
    }

    public async Task<ProductCategoryMap> GetByIdAsync(int id)
    {
        return await _productCategoryMapRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(ProductCategoryMap productCategoryMap)
    {
        await _productCategoryMapRepository.CreateAsync(productCategoryMap);
    }

    public async Task UpdateAsync(ProductCategoryMap productCategoryMap)
    {
        await _productCategoryMapRepository.UpdateAsync(productCategoryMap);
    }

    public async Task DeleteAsync(int id)
    {
        await _productCategoryMapRepository.DeleteAsync(id);
    }

    public async Task DeleteByProductIdAsync(int productId)  // New Method
    {
        await _productCategoryMapRepository.DeleteByProductIdAsync(productId);
    }

    public async Task DeleteByCategoryIdAsync(int categoryId)  // New Method
    {
        await _productCategoryMapRepository.DeleteByCategoryIdAsync(categoryId);
    }
    
    public async Task<List<ProductCategoryMap>> GetByProductIdAsync(int productId)
    {
        return (List<ProductCategoryMap>)await _productCategoryMapRepository.GetByProductIdAsync(productId);
    }

    public async Task<List<ProductCategoryMap>> GetByCategoryIdAsync(int categoryId)
    {
        return (List<ProductCategoryMap>)await _productCategoryMapRepository.GetByCategoryIdAsync(categoryId);
    }
}