using System.ComponentModel.DataAnnotations;

namespace SimpraFinal.API.DTOs;

public class CouponDTO
{
    public int Id { get; set; }

    [Required]
    [StringLength(maximumLength:10)]
    public string Code { get; set; }

    [Required]
    public decimal Amount { get; set; } // represents the coupon amount

    [Required]
    public DateTime ValidFrom { get; set; }

    [Required]
    public DateTime ValidTo { get; set; }
    
    [Required]
    public decimal MinRequiredAmount { get; set; }

    public bool IsActive { get; set; }
    
    public bool IsUsed { get; set; }
}