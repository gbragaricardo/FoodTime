using FoodTime.Data.Mappings;
using FoodTime.Models;
using Microsoft.EntityFrameworkCore;


namespace FoodTime.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderProductMap());
            modelBuilder.ApplyConfiguration(new PaymentMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new RestaurantMap());
        }   
    }
}
