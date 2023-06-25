using System.ComponentModel.DataAnnotations;

namespace SimpraFinal.API.DTOs;

public class ProductCategoryMapDTO
{
    public int Id { get; set; }
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int CategoryId { get; set; }
}