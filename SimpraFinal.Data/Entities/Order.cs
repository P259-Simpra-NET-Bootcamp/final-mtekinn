using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpraFinal.Data.Entities;

public class Order
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(9)]
    public string OrderNumber { get; set; }

    [ForeignKey("UserId")]
    public int UserId { get; set; }
    public User User { get; set; }

    [ForeignKey("CouponId")]
    public int? CouponId { get; set; }
    public Coupon Coupon { get; set; }

    public decimal CouponAmount { get; set; }
    public int PointAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal BillingAmount { get; set; }
    public decimal BasketAmount { get; set; }

    public ICollection<OrderDetail> OrderDetails { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsPaid { get; set; }
}