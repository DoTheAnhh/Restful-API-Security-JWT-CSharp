using Microsoft.EntityFrameworkCore;
using Project_01.Models;
using Type = Project_01.Models.Type;

namespace Project_01.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        #region DBSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    UserId = 1,
                    UserName = "admin", 
                    Email = "admin@example.com", 
                    PasswordHash = HashPassword("123"), 
                    Role = "Admin" 
                },
                new User 
                { 
                    UserId = 2,
                    UserName = "user", 
                    Email = "user@example.com", 
                    PasswordHash = HashPassword("123"), 
                    Role = "User" 
                }
            );
        }
        
        private static string HashPassword(string password)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256())
            {
                var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }
    }
}
