using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mobile_Store_MS.Data.Model;
using Mobile_Store_MS.Data.Model.Company;
using Mobile_Store_MS.Data.Model.Customer;
using Mobile_Store_MS.Data.Model.Messages;
using Mobile_Store_MS.Data.Model.Order;
using Mobile_Store_MS.Data.Model.Stock;
using Mobile_Store_MS.Data.Model.Store;
using Mobile_Store_MS.Data.Model.Vendor;

namespace Mobile_Store_MS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CompanyModel>()
             .HasMany(a => a.Brand)
             .WithOne(b => b.model)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CompanyModel>()
             .HasMany(a => a.Vendor)
             .WithOne(b => b.model)
             .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<CompanyModel>()
            //  .HasMany(a => a.Orders)
            //  .WithOne(b => b.CompanyModel)
            //  .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BrandModel>()
              .HasMany(a => a.Orders)
              .WithOne(b => b.BrandModel)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BrandModel>()
              .HasMany(a => a.Images)
              .WithOne(b => b.model)
              .OnDelete(DeleteBehavior.Cascade);
          
            modelBuilder.Entity<BrandModel>()
            .HasMany(a => a.Purchasing)
            .WithOne(b => b.Brand_model)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BrandModel>()
             .HasMany(a => a.Stock)
             .WithOne(b => b.Model)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Customer>()
             .HasMany(a => a.Order)
             .WithOne(b => b.Cus_model)
             .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Vendor>()
            .HasMany(a => a.Purchasing)
            .WithOne(b => b.Vendor_Model)
            .OnDelete(DeleteBehavior.Cascade);
          

            modelBuilder.Entity<Store>()
           .HasMany(a => a.Purchasing)
           .WithOne(b => b.Store_Model)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Store>()
          .HasMany(a => a.Order)
          .WithOne(b => b.Store_Model)
          .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Store>()
               .HasMany(a => a.Stock)
               .WithOne(b => b.Store)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Store>()
             .HasMany(a => a.Employees)
             .WithOne(b => b.Store)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Purchasing>()
           .HasOne(a => a.user)
           .WithMany(b => b.Purchasing_Model)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
           .HasOne(a => a.user_Model)
           .WithMany(b => b.Order_Model)
           .OnDelete(DeleteBehavior.Restrict);

       
            modelBuilder.Entity<Order>()
            .HasMany(a => a.Products)
            .WithOne(b => b.Order)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
          .HasMany(a => a.Charges)
          .WithOne(b => b.Order)
          .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<message>()
             .HasOne(a => a.Sender)
             .WithMany(b => b.Messages)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Notifications>()
           .HasOne(a => a.User)
           .WithMany(b => b.Notifications)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CompanyModel>(entity =>
            {
                entity.HasIndex(e => e.Com_name).IsUnique();
            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.CustRef).IsUnique();
            });
            modelBuilder.Entity<OrderCharges>(entity =>
            {
                entity.HasIndex(e => new { e.priority,e.order_id}).IsUnique();
            }); 
        }

        public DbSet<CompanyModel> CompanyModel { get; set; }
        public DbSet<BrandModel> BrandModel { get; set; }
        public DbSet<ModelImages> Images { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderCharges> OrderCharges { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Purchasing> Purchasings { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<message> Messages { get; set; }
        public DbSet<Notifications> Notification { get; set; }
    }
}
