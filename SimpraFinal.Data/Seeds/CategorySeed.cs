using Microsoft.EntityFrameworkCore;
using SimpraFinal.Data.Context;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Data.Seeds;

public static class CategorySeed
{
    public static void Seed(SimpraFinalDbContext context)
    {
        if (!context.Categories.Any())
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Categories ON");

            context.Categories.AddRange(
                new Category 
                {
                    Name = "Electronics",
                    Description = "Electronic items",
                    Url = "/category/electronics",
                    Tags = "electronics, gadgets, technology"
                },
                new Category 
                {
                    Name = "Clothing",
                    Description = "Fashion and clothing items",
                    Url = "/category/clothing",
                    Tags = "clothing, fashion, apparel"
                },
                new Category 
                {
                    Name = "Books",
                    Description = "Books and literature",
                    Url = "/category/books",
                    Tags = "books, literature, reading"
                },
                new Category 
                {
                    Name = "Fresh Produce",
                    Description = "Fresh fruits and vegetables",
                    Url = "/category/fresh-produce",
                    Tags = "fruits, vegetables, fresh produce"
                },
                new Category 
                {
                    Name = "Bakery",
                    Description = "Freshly baked bread and pastries",
                    Url = "/category/bakery",
                    Tags = "bakery, bread, pastries"
                });
            context.SaveChanges();
            
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Categories OFF");
        }
    }
}