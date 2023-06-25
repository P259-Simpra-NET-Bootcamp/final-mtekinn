using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpraFinal.Data.Entities;

public class OrderDetail
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("OrderId")]
    public int OrderId { get; set; }
    public Order Order { get; set; }

    [ForeignKey("ProductId")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }
    
    public int PointsEarned => (int)Math.Floor(Price * Quantity / 10);
}