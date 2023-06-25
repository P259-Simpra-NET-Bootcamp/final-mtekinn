using System.ComponentModel.DataAnnotations;

namespace SimpraFinal.API.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    public string OrderNumber { get; set; }
    [Required]
    public int UserId { get; set; }
    public int? CouponId { get; set; }
    public decimal CouponAmount { get; set; }
    [Required]
    [Range(0, 1000)]
    public decimal TotalAmount { get; set; }
    public decimal BillingAmount { get; set; }
    public decimal BasketAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderDetailDTO> OrderDetails { get; set; }
    public bool IsPaid { get; set; }
}