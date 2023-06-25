using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SimpraFinal.Data.Entities;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Username { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [Required]
    [EmailAddress]
    [MaxLength(50)]
    public string Email { get; set; }
    
    [MaxLength(50)]
    public string Phone { get; set; }

    public bool IsAdmin { get; set; }

    public UserRole UserRole { get; set; }
    public UserStatus UserStatus { get; set; }
    public decimal WalletBalance { get; set; }
    public int PointsBalance { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; } // Adding Salt for secure password hashing
    

    // Adding Orders list to establish relationship
    public ICollection<Order> Orders { get; set; }
}

public enum UserRole
{
    NormalUser,
    Admin
}

public enum UserStatus
{
    Active,
    Inactive
}