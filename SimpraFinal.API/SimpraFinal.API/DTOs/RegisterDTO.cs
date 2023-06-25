using System.ComponentModel.DataAnnotations;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.API.DTOs;

public class RegisterDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    public string Phone { get; set; }
    public bool IsAdmin { get; set; }
    public UserRole UserRole { get; set; }
    public UserStatus UserStatus { get; set; }
    public decimal WalletBalance { get; set; }
    public int PointsBalance { get; set; }
}