using Microsoft.EntityFrameworkCore;
using SimpraFinal.Data.Context;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly SimpraFinalDbContext _context;
    
    public ProductRepository(SimpraFinalDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetProductsWithCategoriesAsync()
    {
        return await _context.Products
            .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetActiveProductsWithCategoriesAsync()
    {
        return await _context.Products
            .Where(p => p.IsActive)
            .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
            .ToListAsync();
    }

    public async Task<Product> GetProductByIdWithCategoryAsync(int productId)
    {
        return await _context.Products
            .Where(p => p.Id == productId)
            .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
            .FirstOrDefaultAsync();
    }
    
    public async Task<Product> GetProductWithCategoriesByIdAsync(int id)
    {
        return await _context.Products
            .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
            .SingleOrDefaultAsync(p => p.Id == id);
    }
    
    public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
    {
        return await _context.ProductCategoryMaps
            .Where(pc => pc.CategoryId == categoryId)
            .Select(pc => pc.Product)
            .ToListAsync();
    }
    
    public async Task<bool> IsProductAvailableAsync(int productId, int quantity)
    {
        var product = await _context.Products.FindAsync(productId);
        return product != null && product.Stock >= quantity;
    }
}
