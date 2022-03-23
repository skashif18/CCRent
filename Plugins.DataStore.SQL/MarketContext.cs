using CoreBusiness;
using CoreBusiness.EmployeeRelations;
using CoreBusiness.Masters;
using Microsoft.EntityFrameworkCore;
using System;

namespace Plugins.DataStore.SQL
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        // master Dtaset
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CompanyGroup> CompanyGroups { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanySelection> CompanySelections { get; set; }
        public DbSet<CostCenter> CostCenters { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Group> Groups { get; set; } 
        public DbSet<PayHead> PayHeads { get; set; }
        public DbSet<StaffCategory> StaffCategories { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        // Employee Dtaset
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            // seeding some data
            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = 1, Name = "Beverage", Description = "Beverage" },
                    new Category { CategoryId = 2, Name = "Bakery", Description = "Bakery" },
                    new Category { CategoryId = 3, Name = "Meat", Description = "Meat" }
                );

            modelBuilder.Entity<Product>().HasData(
                    new Product { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 100, Price = 1.99 },
                    new Product { ProductId = 2, CategoryId = 1, Name = "Canada Dry", Quantity = 200, Price = 1.99 },
                    new Product { ProductId = 3, CategoryId = 2, Name = "Whole Wheat Bread", Quantity = 300, Price = 1.50 },
                    new Product { ProductId = 4, CategoryId = 2, Name = "White Bread", Quantity = 300, Price = 1.50 }
                );
        }
    }
}
