using E_Commerce_SystemERD_Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce_SystemERD_Models
{
    public class ECommerceContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=DESKTOP-U403BM4;Database=ECommerceDB;Trusted_Connection=True;TrustServerCertificate=True;")
                // Enable EF Core Lazy Loading Proxies
                .UseLazyLoadingProxies();
        }

    }
}
