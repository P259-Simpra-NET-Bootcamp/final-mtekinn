using System.ComponentModel.DataAnnotations;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.API.DTOs;

public class UserDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    [Required]
    [StringLength(maximumLength: 50)]
    public string Username { get; set; }
    [Required]
    [StringLength(maximumLength: 50, MinimumLength = 6)]
    public string Password { get; set; }
    public string Phone { get; set; }
    public bool IsAdmin { get; set; }
    public UserRole UserRole { get; set; }
    public UserStatus UserStatus { get; set; }
    public decimal WalletBalance { get; set; }
    public int PointsBalance { get; set; }
    
    // Ensure that the DTO class (UserDTO) includes the Token property.
    public string Token { get; set; }
}