using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SimpraFinal.Business.OtherExtensions;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IConfiguration _configuration;
    
    public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _configuration = configuration;
    }
    public async Task<User> AuthenticateAsync(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            return null;
        
        var user = await _userRepository.GetByUsernameAsync(username);
        
        // Check if username exists and password is correct
        if (user == null || !_passwordHasher.VerifyPasswordHash(password, user.PasswordHash))
            return null;

        // Authentication successful
            return user;
    }

    public Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return _userRepository.GetUsers();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }
    
    public async Task<User> Register(User user, string password, UserRole role)
    {
        byte[] passwordHash, passwordSalt;
        _passwordHasher.CreatePasswordHash(password, out passwordHash, out passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        user.UserRole = role;  // Assigning role here

        await _userRepository.AddAsync(user);
        await _userRepository.SaveAsync();

        return user;
    }


    public async Task<bool> UserExists(string username)
    {
        return await _userRepository.UserExistsAsync(username);
    }
    
    public async Task UpdateAsync(User userParam, string password = null)
    {
        var user = await _userRepository.GetByIdAsync(userParam.Id);
        
        if (user == null)
            throw new AppException("User not found");
        
        if (userParam.Username != user.Username)
            throw new AppException($"Username {userParam.Username} is not the same as {user.Username}");

        // Update user properties
        user.FirstName = userParam.FirstName;
        user.LastName = userParam.LastName;
        user.Username = userParam.Username;

        // Update password if it was entered
        if (!string.IsNullOrWhiteSpace(password))
        {
            byte[] passwordHash, passwordSalt;
            _passwordHasher.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
        }
        await _userRepository.UpdateAsync(user);
    }

    public async Task DeleteAsync(int id)
    {
        await _userRepository.DeleteAsync(id);
    }

    public async Task<bool> IncrementPointsBalanceAsync(int userId, int points)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null) return false;

        user.WalletBalance += points;
        await _userRepository.UpdateAsync(user);
        return true;
    }
    
    public async Task<bool> DecrementPointsBalanceAsync(int userId, int points)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null || user.WalletBalance < points) return false;

        user.WalletBalance -= points;
        await _userRepository.UpdateAsync(user);
        return true;
    }

    public async Task<bool> RedeemPointsAsync(int userId, int points)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null || user.WalletBalance < points) return false;

        var discountAmount = points * 0.01M; // Assuming each point equals $0.01
        user.WalletBalance += discountAmount;
        user.WalletBalance -= points;
        await _userRepository.UpdateAsync(user);
        return true;
    }
    
    public string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:AccessTokenExpiration"])),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"]
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<User> Register(User user, string password, string email)
    {
        byte[] passwordHash, passwordSalt;
        _passwordHasher.CreatePasswordHash(password, out passwordHash, out passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        user.Email = email;

        await _userRepository.AddAsync(user);
        await _userRepository.SaveAsync();

        return user;
    }
}