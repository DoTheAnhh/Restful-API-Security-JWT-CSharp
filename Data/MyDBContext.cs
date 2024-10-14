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
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        #endregion

    }
}
