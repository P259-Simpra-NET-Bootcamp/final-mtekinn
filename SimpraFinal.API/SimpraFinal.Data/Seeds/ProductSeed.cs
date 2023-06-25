using Microsoft.EntityFrameworkCore;
using SimpraFinal.Data.Context;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Data.Seeds;

public static class ProductSeed
{
    public static void Seed(SimpraFinalDbContext context)
    {
        if (!context.Products.Any())
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Products ON");
            
            context.Products.AddRange(
                new Product
                {
                    Name = "Apple iPhone 12 Pro Max",
                    Description = "Apple iPhone 12 Pro Max 128GB",
                    Price = 1000,
                    Stock = 10,  // Assuming initial stock is 10
                    MaxPoint = 100,  // Assuming max point to be earned is 100
                    PointEarningRate = 0.1M  // Assuming point earning rate is 10%
                },
                new Product
                {
                    Name = "PlayStation 5",
                    Description = "Sony PlayStation 5",
                    Price = 500,
                    Stock = 5,  // Assuming initial stock is 5
                    MaxPoint = 50,  // Assuming max point to be earned is 50
                    PointEarningRate = 0.1M  // Assuming point earning rate is 10%
                },
                new Product
                {
                    Name = "Xbox Series X",
                    Description = "Microsoft Xbox Series X",
                    Price = 500,
                    Stock = 5,  // Assuming initial stock is 5
                    MaxPoint = 50,  // Assuming max point to be earned is 50
                    PointEarningRate = 0.1M  // Assuming point earning rate is 10%
                },
                new Product
                {
                    Name = "Samsung Galaxy S21 Ultra",
                    Description = "Samsung Galaxy S21 Ultra 128GB",
                    Price = 1000,
                    Stock = 10,  // Assuming initial stock is 10
                    MaxPoint = 100,  // Assuming max point to be earned is 100
                    PointEarningRate = 0.1M  // Assuming point earning rate is 10%
                });
            context.SaveChanges();
            
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Products OFF");
        }
    }
}