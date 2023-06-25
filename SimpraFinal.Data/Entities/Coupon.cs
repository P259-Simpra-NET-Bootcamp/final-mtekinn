using System.ComponentModel.DataAnnotations;

namespace SimpraFinal.Data.Entities;

public class Coupon
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(10)]
    public string Code { get; set; }

    [Required]
    public decimal Amount { get; set; } // represents the coupon amount

    [Required]
    public DateTime ValidFrom { get; set; }

    [Required]
    public DateTime ValidTo { get; set; }

    [Required]
    public decimal MinRequiredAmount { get; set; }

    [Required]
    public bool IsActive { get; set; }
    
    [Required]
    public bool IsUsed { get; set; }
    
    // A coupon can be applied to many orders
    public ICollection<Order> Orders { get; set; }
}
