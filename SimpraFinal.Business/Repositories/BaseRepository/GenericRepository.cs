using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SimpraFinal.Business.Interfaces.BaseRepository;
using SimpraFinal.Data.Context;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly SimpraFinalDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(SimpraFinalDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task CreateAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(int id)
    {
        var entityToDelete = await _dbSet.FindAsync(id);
        if (entityToDelete != null)
        {
            _dbSet.Remove(entityToDelete);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
    {
        _dbSet.UpdateRange(entities);
        await _context.SaveChangesAsync();
    }
        
    public async Task DeleteRangeAsync(IEnumerable<int> ids)
    {
        foreach(var id in ids)
        {
            var entityToDelete = await _dbSet.FindAsync(id);
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
        }
        await _context.SaveChangesAsync();
    }
}
