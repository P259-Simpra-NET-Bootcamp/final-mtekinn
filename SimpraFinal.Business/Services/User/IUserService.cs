using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public interface IUserService
{
    Task<User> AuthenticateAsync(string username, string password);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetByIdAsync(int id);
    Task<User> Register(User user, string password, UserRole role);
    Task<bool> UserExists(string username);
    Task UpdateAsync(User user, string password = null);
    Task DeleteAsync(int id);
    Task<bool> IncrementPointsBalanceAsync(int userId, int points);
    Task<bool> DecrementPointsBalanceAsync(int userId, int points);
    Task<bool> RedeemPointsAsync(int userId, int points);
    string GenerateJwtToken(User user);
    Task<User> Register(User user, string password, string email);
}