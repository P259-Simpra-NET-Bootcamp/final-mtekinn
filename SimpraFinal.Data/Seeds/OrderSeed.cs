using Microsoft.EntityFrameworkCore;
using SimpraFinal.Data.Context;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Data.Seeds;

public static class OrderSeed
{
    public static void Seed(SimpraFinalDbContext context)
    {
        if (!context.Orders.Any())
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Orders ON");

            context.Orders.AddRange(
                new Order
                {
                    OrderNumber = "ORDER0001",
                    UserId = 1, // Assuming User with Id 1 exists
                    CouponId = 1, // Assuming Coupon with Id 1 exists
                    CouponAmount = 10, // CouponAmount based on Coupon with Id 1
                    PointAmount = 0,
                    TotalAmount = 110,
                    BillingAmount = 100,
                    OrderDate = new DateTime(2023, 6, 25),
                    IsPaid = true,
                },
                new Order
                {
                    OrderNumber = "ORDER0002",
                    UserId = 2, // Assuming User with Id 2 exists
                    CouponId = null, // No coupon used
                    CouponAmount = 0,
                    PointAmount = 0,
                    TotalAmount = 150,
                    BillingAmount = 150,
                    OrderDate = new DateTime(2023, 6, 26),
                    IsPaid = false,
                });
            context.SaveChanges();
            
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Orders OFF");
        }
    }
}