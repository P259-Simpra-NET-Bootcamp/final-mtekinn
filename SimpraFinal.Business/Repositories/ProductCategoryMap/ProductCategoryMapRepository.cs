using Microsoft.EntityFrameworkCore;
using SimpraFinal.Data.Context;
using SimpraFinal.Data.Context.Factory;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public class ProductCategoryMapRepository : GenericRepository<ProductCategoryMap>, IProductCategoryMapRepository
{
    private readonly SimpraFinalDbContext _context;

    public ProductCategoryMapRepository(SimpraFinalDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductCategoryMap>> GetByProductIdAsync(int productId)
    {
        return await _context.ProductCategoryMaps
            .Where(pcm => pcm.ProductId == productId)
            .Include(pcm => pcm.Product)
            .Include(pcm => pcm.Category)
            .ToListAsync();
    }

    public async Task<IEnumerable<ProductCategoryMap>> GetByCategoryIdAsync(int categoryId)
    {
        return await _context.ProductCategoryMaps
            .Where(pcm => pcm.CategoryId == categoryId)
            .Include(pcm => pcm.Product)
            .Include(pcm => pcm.Category)
            .ToListAsync();
    }

    public async Task DeleteByProductIdAsync(int productId)  // New Method
    {
        var productCategoryMaps = _context.ProductCategoryMaps
            .Where(pcm => pcm.ProductId == productId);
            
        _context.ProductCategoryMaps.RemoveRange(productCategoryMaps);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByCategoryIdAsync(int categoryId)  // New Method
    {
        var productCategoryMaps = _context.ProductCategoryMaps
            .Where(pcm => pcm.CategoryId == categoryId);
            
        _context.ProductCategoryMaps.RemoveRange(productCategoryMaps);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(int id) // New method
    {
        var productCategoryMap = await _context.ProductCategoryMaps.FindAsync(id);
        if (productCategoryMap != null)
        {
            _context.ProductCategoryMaps.Remove(productCategoryMap);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task<IEnumerable<ProductCategoryMap>> GetAllProductCategoryMapsAsync() // New method
    {
        return await _context.ProductCategoryMaps
            .Include(pcm => pcm.Product)
            .Include(pcm => pcm.Category)
            .ToListAsync();
    }
}
