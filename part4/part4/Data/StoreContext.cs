using System;
using Microsoft.EntityFrameworkCore;
using part4.Models;

namespace part4.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            //modelBuilder.Entity<Product>().ToTable("Product");
            //modelBuilder.Entity<Order>().ToTable("Order");
        }
    }

}