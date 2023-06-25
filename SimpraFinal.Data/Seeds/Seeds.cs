using Microsoft.EntityFrameworkCore;
using SimpraFinal.Data.Context;

namespace SimpraFinal.Data.Seeds;
public static class Seeds
{
    public static void Initialize(SimpraFinalDbContext context)
    {
        context.Database.Migrate(); // Applies any pending migrations for the context to the database. Will create the database if it does not already exist.

        CategorySeed.Seed(context);
        ProductSeed.Seed(context);
        UserSeed.Seed(context);
        CouponSeed.Seed(context);
        OrderSeed.Seed(context);
        OrderDetailSeed.Seed(context);
        ProductCategoryMapSeed.Seed(context);

        context.SaveChanges();
    }
}