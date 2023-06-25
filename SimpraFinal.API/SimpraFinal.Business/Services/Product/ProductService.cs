using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        await _productRepository.CreateAsync(product);
        return product;
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        await _productRepository.UpdateAsync(product);
        return product;
    }

    public async Task DeleteProductAsync(int id)
    {
        await _productRepository.DeleteAsync(id);
    }

    public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId)
    {
        return (List<Product>)await _productRepository.GetProductsByCategoryIdAsync(categoryId);
    }

    public async Task<bool> IsProductAvailableAsync(int productId, int quantity)
    {
        return await _productRepository.IsProductAvailableAsync(productId, quantity);
    }
}