using System.ComponentModel.DataAnnotations;

namespace SimpraFinal.API.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }

    [Required]
    [StringLength(maximumLength:100)]
    public string Name { get; set; }

    [StringLength(maximumLength:500)]
    public string Description { get; set; }

    [StringLength(maximumLength:200)]
    public string Url { get; set; }

    [StringLength(maximumLength:500)]
    public string Tags { get; set; }

    public bool IsActive { get; set; }
}