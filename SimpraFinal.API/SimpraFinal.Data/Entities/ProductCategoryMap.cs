using System.ComponentModel.DataAnnotations;

namespace SimpraFinal.Data.Entities;

public class ProductCategoryMap
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [Required]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}