using ConstumerShoppingAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ConstumerShoppingAPI.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer_Product>().HasKey(e => new { e.ProductId, e.CustomerId });

            modelBuilder.Entity<Customer_Product>().HasOne(e => e.Customer).WithMany(e => e.customer_product).HasForeignKey(e => e.CustomerId);

            modelBuilder.Entity<Customer_Product>().HasOne(e => e.Product).WithMany(e => e.customer_product).HasForeignKey(e => e.ProductId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Customer_Product> customerproducts { get; set; }   

    }
}
