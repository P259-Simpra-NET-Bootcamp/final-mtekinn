using Microsoft.EntityFrameworkCore;
using SimpraFinal.Data.Context;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Data.Seeds;

public static class OrderDetailSeed
{
    public static void Seed(SimpraFinalDbContext context)
    {
        if (!context.OrderDetails.Any())
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.OrderDetails ON");

            context.OrderDetails.AddRange(
                new OrderDetail
                {
                    OrderId = 1, // Assuming Order with Id 1 exists
                    ProductId = 1, // Assuming Product with Id 1 exists
                    Quantity = 2,
                    Price = 50, // Assuming the price of Product with Id 1 is 50
                },
                new OrderDetail
                {
                    OrderId = 2, // Assuming Order with Id 2 exists
                    ProductId = 2, // Assuming Product with Id 2 exists
                    Quantity = 3,
                    Price = 30, // Assuming the price of Product with Id 2 is 30
                });
            context.SaveChanges();
            
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.OrderDetails OFF");
        }
    }
}