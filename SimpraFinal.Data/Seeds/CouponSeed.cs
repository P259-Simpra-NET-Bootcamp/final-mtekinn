using Microsoft.EntityFrameworkCore;
using SimpraFinal.Data.Context;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Data.Seeds;

public static class CouponSeed
{
    public static void Seed(SimpraFinalDbContext context)
    {
        if (!context.Coupons.Any())
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Coupons ON");

            context.Coupons.AddRange(
                new Coupon
                {
                    Code = "SUMMER10",
                    Amount = 10,
                    ValidFrom = new DateTime(2023, 6, 1),
                    ValidTo = new DateTime(2024, 8, 31),
                    MinRequiredAmount = 50,
                    IsActive = true
                },
                new Coupon
                {
                    Code = "WINTER15",
                    Amount = 15,
                    ValidFrom = new DateTime(2023, 12, 1),
                    ValidTo = new DateTime(2024, 12, 31),
                    MinRequiredAmount = 100,
                    IsActive = true
                },
                new Coupon
                {
                    Code = "SPRING20",
                    Amount = 20,
                    ValidFrom = new DateTime(2023, 3, 1),
                    ValidTo = new DateTime(2024, 6, 30),
                    MinRequiredAmount = 200,
                    IsActive = true
                },
                new Coupon
                {
                    Code = "AUTUMN25",
                    Amount = 25,
                    ValidFrom = new DateTime(2023, 9, 1),
                    ValidTo = new DateTime(2024, 11, 30),
                    MinRequiredAmount = 250,
                    IsActive = true
                });
            context.SaveChanges();

            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Coupons OFF");
        }
    }
}