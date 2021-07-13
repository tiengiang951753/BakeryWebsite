using BakeryProj.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using BakeryProj.Data.Configurations;
using BakeryProj.Helpers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace BakeryProj.Data
{
    public class BakeryContext : IdentityDbContext  
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Account> Accounts {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source=Bakery.db");
        }  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {       
                base.OnModelCreating(modelBuilder);
                modelBuilder.ApplyConfiguration(new ProductConfiguration());
                modelBuilder.ApplyConfiguration(new ProductConfiguration()).Seed();
                modelBuilder.Entity<Item>(eb =>
                {
                    eb.HasNoKey();
                });
                modelBuilder.Entity<Customer>(eb =>
                {
                    eb.HasNoKey();
                });
                modelBuilder.Entity<OrderDetails>(eb =>
                {
                   modelBuilder.Entity<OrderDetails>()
                    .HasKey(c => new { c.Id, c.ID_Od });

                });
                modelBuilder.Entity<Order>(eb =>
                {
                   modelBuilder.Entity<Order>()
                    .HasKey(c => new { c.ID_Od });

                });
                modelBuilder.Entity<Account>(eb =>
                {
                   modelBuilder.Entity<Account>()
                    .HasKey(c => new { c.Id });
                });
        }
    }
}