using System;
using Microsoft.EntityFrameworkCore;
using OrdersApp.Domain.Core.Entities;

namespace OrdersApp.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInOrder> ProductsInOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product { Id = 1, Name = "Product #1", Price = 100M },
                    new Product { Id = 2, Name = "Product #2", Price = 10M },
                    new Product { Id = 3, Name = "Product #3", Price = 5M },
                    new Product { Id = 4, Name = "Product #4", Price = 10M });

            modelBuilder.Entity<Order>()
                .HasData(
                    new Order { Id = 1, CreateDate = new DateTime(2017, 10, 20, 1, 10, 0), Status = 0 },
                    new Order { Id = 2, CreateDate = new DateTime(2017, 1, 10, 5, 30, 0), Status = 1 });

            modelBuilder.Entity<ProductInOrder>()
                .HasData(
                    new ProductInOrder { Id = 1, OrderId = 1, ProductId = 1, ProductCount = 1 },
                    new ProductInOrder { Id = 2, OrderId = 1, ProductId = 2, ProductCount = 5 },
                    new ProductInOrder { Id = 3, OrderId = 2, ProductId = 3, ProductCount = 1 },
                    new ProductInOrder { Id = 4, OrderId = 2, ProductId = 4, ProductCount = 2 }
                    );
        }
    }
}
