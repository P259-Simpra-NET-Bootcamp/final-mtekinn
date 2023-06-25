using System.ComponentModel.DataAnnotations;

namespace SimpraFinal.Data.Entities;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(200)]
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    public int Stock { get; set; }

    [Required]
    public int MaxPoint { get; set; } // The max amount of points the user can earn from this product

    [Required]
    public decimal PointEarningRate { get; set; } // The rate at which the user earns points from purchasing this product

    public ICollection<ProductCategoryMap> ProductCategories { get; set; }
    
    // This method calculates points earned based on point earning rate and max point.
    public int CalculatePoints(decimal price, int quantity)
    {
        var points = (int)Math.Floor(price * quantity * PointEarningRate);
        return Math.Min(points, MaxPoint);
    }
}