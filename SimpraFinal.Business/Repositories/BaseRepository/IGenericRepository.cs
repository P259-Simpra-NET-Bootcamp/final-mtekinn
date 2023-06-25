using System.Linq.Expressions;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business.Interfaces.BaseRepository;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(int id);
    Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task CreateRangeAsync(IEnumerable<TEntity> entities);
    Task UpdateRangeAsync(IEnumerable<TEntity> entities);
    Task DeleteRangeAsync(IEnumerable<int> ids);
}