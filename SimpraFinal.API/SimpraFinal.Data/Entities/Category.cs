using System.ComponentModel.DataAnnotations;

namespace SimpraFinal.Data.Entities;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [MaxLength(500)]
    public string Description { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Url { get; set; }
    
    [MaxLength(500)]
    public string Tags { get; set; }
    
    // public ICollection<string> Tags { get; set; }
    
    public bool IsActive { get; set; } = true;
    
    // This will handle the many-to-many relationship between Product and Category
    public ICollection<ProductCategoryMap> ProductCategories { get; set; }
}