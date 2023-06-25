using Microsoft.EntityFrameworkCore;
using SimpraFinal.Data.Entities;
using SimpraFinal.Data.Seeds;


namespace SimpraFinal.Data.Context;

public class SimpraFinalDbContext : DbContext
{
    public string ConnectionString { get; set; }
    
    public SimpraFinalDbContext(DbContextOptions<SimpraFinalDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategoryMap> ProductCategoryMaps { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductCategoryMap>()
            .HasKey(pc => new { pc.ProductId, pc.CategoryId });
        modelBuilder.Entity<ProductCategoryMap>()
            .HasOne(pc => pc.Product)
            .WithMany(p => p.ProductCategories)
            .HasForeignKey(pc => pc.ProductId);
        modelBuilder.Entity<ProductCategoryMap>()
            .HasOne(pc => pc.Category)
            .WithMany(c => c.ProductCategories)
            .HasForeignKey(pc => pc.CategoryId);

        modelBuilder.Entity<Coupon>()
            .HasIndex(c => c.Code)
            .IsUnique();
            
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();
        
        modelBuilder.Entity<User>()
            .Property(u => u.UserRole)
            .HasConversion<string>();
        
        modelBuilder.Entity<User>()
            .Property(u => u.UserStatus)
            .HasConversion<string>();

        modelBuilder.Entity<Order>()
            .HasIndex(o => o.OrderNumber)
            .IsUnique();
        
        base.OnModelCreating(modelBuilder);
    }
}