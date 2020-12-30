using backend_school_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_school_api.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Map entities to tables
            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<OrderLine>().ToTable("orderlines");
            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<User>().ToTable("users");

            // Configure Primary Keys
            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
            modelBuilder.Entity<User>().HasKey(u => u.UserId);

            // Configure composit keys
            modelBuilder.Entity<OrderLine>().HasKey(ol => new {ol.OrderId, ol.ProductId });

            //

        }

        public DbSet<Product> Product { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<OrderLine> OrderLine { get; set; }
    }
}
