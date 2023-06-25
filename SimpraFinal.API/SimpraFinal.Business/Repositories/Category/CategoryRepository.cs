using Microsoft.EntityFrameworkCore;
using SimpraFinal.Data.Context;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly SimpraFinalDbContext _dbContext;

    public CategoryRepository(SimpraFinalDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Category> GetCategoryWithProductsAsync(int id)
    {
        return await _dbContext.Categories
            .Include(c => c.ProductCategories)
            .ThenInclude(pc => pc.Product)
            .SingleOrDefaultAsync(c => c.Id == id);
    }
    
    public async Task<List<Category>> GetAllWithProductsAsync()
    {
        return await _dbContext.Categories
            .Include(c => c.ProductCategories)
            .ThenInclude(pc => pc.Product)
            .ToListAsync();
    }
    
    public async Task<List<Category>> GetActiveCategoriesAsync()
    {
        return await _dbContext.Categories
            .Where(c => c.IsActive)
            .ToListAsync();
    }
}