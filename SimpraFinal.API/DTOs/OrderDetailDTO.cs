using System.ComponentModel.DataAnnotations;

namespace SimpraFinal.API.DTOs;

public class OrderDetailDTO
{
    public int Id { get; set; }
    [Required]
    public int OrderId { get; set; }
    [Required]
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    [Required]
    public int Quantity { get; set; }
    public int PointsEarned { get; set; }
}