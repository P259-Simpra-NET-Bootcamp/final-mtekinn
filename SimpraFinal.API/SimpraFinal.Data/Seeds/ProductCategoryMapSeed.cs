using Microsoft.EntityFrameworkCore;
using SimpraFinal.Data.Context;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Data.Seeds;

public static class ProductCategoryMapSeed
{
    public static void Seed(SimpraFinalDbContext context)
    {
        if (!context.ProductCategoryMaps.Any())
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ProductCategoryMaps ON");
            
            context.ProductCategoryMaps.AddRange(
                new ProductCategoryMap
                {
                    ProductId = 1, // id of the product in Product seed data
                    CategoryId = 1, // id of the category in Category seed data
                },
                new ProductCategoryMap
                {
                    ProductId = 2, // id of the product in Product seed data
                    CategoryId = 1, // id of the category in Category seed data
                });
            context.SaveChanges(); // Added SaveChanges call
            
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ProductCategoryMaps OFF");
        }
    }
}