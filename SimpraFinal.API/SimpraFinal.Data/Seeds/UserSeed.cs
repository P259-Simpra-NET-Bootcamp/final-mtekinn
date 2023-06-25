using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SimpraFinal.Data.Context;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Data.Seeds;
public static class UserSeed
{
    public static void Seed(SimpraFinalDbContext context)
    {
        if (!context.Users.Any())
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Users ON");
            
            var hmac = new HMACSHA512();

            context.Users.AddRange(
                new User 
                {
                    Username = "muhammetTekin", 
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("12345")),
                    FirstName = "Muhammet", 
                    LastName = "Tekin",
                    Email = "muhammet@tekin.com",
                    PointsBalance = 500,
                    WalletBalance = 5550,
                    UserStatus = UserStatus.Active,
                    UserRole = UserRole.NormalUser,
                    IsAdmin = false
                },
                new User 
                {
                    Username = "mehmetTekin", 
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("123456")),
                    FirstName = "Mehmet", 
                    LastName = "Tekin",
                    Email = "mehmet@tekin.com",
                    PointsBalance = 250,
                    WalletBalance = 2500,
                    UserStatus = UserStatus.Active,
                    UserRole = UserRole.NormalUser,
                    IsAdmin = false
                },
                new User
                {
                    Username = "admin",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("123456789")),
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "admin@admin.com",
                });
            context.SaveChanges();  // Save the changes
            
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Users OFF");
        }
    }
}