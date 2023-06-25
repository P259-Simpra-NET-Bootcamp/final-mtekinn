using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpraFinal.Business.OtherExtensions;
using SimpraFinal.Data.Context;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly SimpraFinalDbContext _context;
    private readonly IPasswordHasher _passwordHasher;

    public UserRepository(SimpraFinalDbContext context, IPasswordHasher passwordHasher) : base(context)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);
    }
    
    public async Task<User> GetByUsernameAsync(string username)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<User> GetUserById(int id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        var users = await _context.Users
            .Select(u => new User
            {
                Id = u.Id,
                Username = u.Username,
                FirstName = u.FirstName,
                LastName = u.LastName,
            })
            .ToListAsync();

        return users;
    }


    
    public async Task<User> Register(User user, string password)
    {
        byte[] passwordHash, passwordSalt;
        _passwordHasher.CreatePasswordHash(password, out passwordHash, out passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        await AddAsync(user);

        return user;
    }
    
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
    
    public async Task<bool> UserExistsAsync(string username)
    {
        return await _context.Users.AnyAsync(u => u.Username == username);
    }

    public async Task<bool> IncrementPointsAsync(int userId, int points)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null)
        {
            return false;
        }
        user.PointsBalance += points;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DecrementPointsAsync(int userId, int points)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null || user.PointsBalance < points)
        {
            return false;
        }
        user.PointsBalance -= points;
        return await _context.SaveChangesAsync() > 0;
    }
    
    public async Task<User> GetUserByIdWithOrdersAsync(int id)
    {
        return await _context.Users
            .Include(u => u.Orders)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IEnumerable<User>> GetUsersWithOrdersAsync()
    {
        return await _context.Users
            .Include(u => u.Orders)
            .ToListAsync();
    }

    public async Task<bool> IncrementWalletBalanceAsync(int userId, decimal amount)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null)
        {
            return false;
        }
        user.WalletBalance += amount;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DecrementWalletBalanceAsync(int userId, decimal amount)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null || user.WalletBalance < amount)
        {
            return false;
        }
        user.WalletBalance -= amount;
        await _context.SaveChangesAsync();
        return true;
    }
}
