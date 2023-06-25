using SimpraFinal.Business.Interfaces.BaseRepository;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetByEmailAsync(string email);
    Task<User> GetByUsernameAsync(string username);
    Task<User> GetUserById(int id);
    Task<IEnumerable<User>> GetUsers();
    Task SaveAsync();
    Task<bool> UserExistsAsync(string username);
    Task AddAsync(User user);
    Task<User> GetUserByIdWithOrdersAsync(int id);
    Task<IEnumerable<User>> GetUsersWithOrdersAsync();
    Task<bool> IncrementWalletBalanceAsync(int userId, decimal amount);
    Task<bool> DecrementWalletBalanceAsync(int userId, decimal amount);
}