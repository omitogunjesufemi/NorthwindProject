﻿using Microsoft.EntityFrameworkCore;
using System.IO;


namespace NorthwindLibrary 
{
    public class NorthwindDbContext : DbContext 
    {
        public NorthwindDbContext (DbContextOptions<NorthwindDbContext> options) : base (options) 
        { 
            
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Category
            modelBuilder.Entity<Category>().Property(c=>c.CategoryName).IsRequired().HasMaxLength(15);

            modelBuilder.Entity<Category>().HasMany(c=>c.Products).WithOne(p=>p.Category);

            // Customer
            modelBuilder.Entity<Customer>().Property(c=>c.CustomerID).IsRequired().HasMaxLength(15);

            modelBuilder.Entity<Customer>().Property(c=>c.CompanyName).IsRequired().HasMaxLength(40);

            modelBuilder.Entity<Customer>().Property(c=>c.ContactName).HasMaxLength(30);

            modelBuilder.Entity<Customer>().Property(c=>c.Country).HasMaxLength(15);

            modelBuilder.Entity<Customer>().HasMany(o=>o.Orders).WithOne(c=>c.Customer);

            // Employee
            modelBuilder.Entity<Employee>().Property(e=>e.LastName).IsRequired().HasMaxLength(20);

            modelBuilder.Entity<Employee>().Property(e=>e.FirstName).IsRequired().HasMaxLength(10);

            modelBuilder.Entity<Employee>().Property(e=>e.Country).HasMaxLength(15);

            modelBuilder.Entity<Employee>().HasMany(e=>e.Orders).WithOne(o=>o.Employee);

            // Product
            modelBuilder.Entity<Product>().Property(p=>p.ProductName).IsRequired().HasMaxLength(40);

            modelBuilder.Entity<Product>().HasOne(c=>c.Category).WithMany(p=>p.Products);

            modelBuilder.Entity<Product>().HasOne(c=>c.Category).WithMany(p=>p.Products);

            modelBuilder.Entity<Product>().HasOne(c=>c.Supplier).WithMany(p=>p.Products);

            // ORDER
            modelBuilder.Entity<Order>().HasOne(o => o.Shipper).WithMany(s => s.Orders).HasForeignKey(o => o.ShipVia);

            // ORDER DETAILS
            modelBuilder.Entity<OrderDetail>().ToTable("Order Details");

            modelBuilder.Entity<OrderDetail>().HasKey(od => new {od.OrderID, od.ProductID});


            // SUPPLIER
            modelBuilder.Entity<Supplier>().Property(c=>c.CompanyName).IsRequired().HasMaxLength(40);

            modelBuilder.Entity<Supplier>().HasMany(s=>s.Products).WithOne(p=>p.Supplier);

        }
    }
}
