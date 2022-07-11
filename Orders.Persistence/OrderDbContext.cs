using Microsoft.EntityFrameworkCore;
using Domain;
using Orders.Persistence.EntityTypeConfigurations;
using Orders.Application.Interfaces;
using Orders.Persistence.DatabaseInit;

namespace Orders.Persistence
{
    public class OrderDbContext : DbContext, IOrderDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.InitDatabase();


            base.OnModelCreating(modelBuilder);
        }

    }
}
