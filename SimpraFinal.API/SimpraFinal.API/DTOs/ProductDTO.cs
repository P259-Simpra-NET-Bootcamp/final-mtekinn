using System.ComponentModel.DataAnnotations;

namespace SimpraFinal.API.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    [Required]
    [StringLength(maximumLength: 100)]
    public string Name { get; set; }
    [Required]
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public int MaxPoint { get; set; }
    public decimal PointEarningRate { get; set; } 
}