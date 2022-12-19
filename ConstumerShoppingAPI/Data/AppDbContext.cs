using ConstumerShoppingAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ConstumerShoppingAPI.Data
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer_Product>().HasKey(e => new { e.ProductId, e.CustomerId});

            modelBuilder.Entity<Customer_Product>().HasOne(e => e.Customer).WithMany(e => e.customer_product).HasForeignKey(e => e.CustomerId);

            modelBuilder.Entity<Customer_Product>().HasOne(e => e.Product).WithMany(e => e.customer_product).HasForeignKey(e => e.ProductId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> produces { get; set; }
        public DbSet<Customer> customers { get; set; }

    }


}
