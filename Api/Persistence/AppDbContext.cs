using System;
using System.Collections.Generic;
using BlazorApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace Api.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) {
    public DbSet<Employee> Employees { get; set; }
    public DbSet<WarrantGrantCase> WarrantGrantCases { get; set; }
    public DbSet<WarrantAllocation> WarrantAllocations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<WarrantGrantCase>(warrantGrantCase =>
        {
            warrantGrantCase
                .HasOne(wgc => wgc.Employee)
                .WithMany(employee => employee.WarrantGrantCases)
                .HasForeignKey(wgc => wgc.EmployeeId);
        });

        modelBuilder.Entity<WarrantAllocation>(warrantAllocation =>
        {
            warrantAllocation
                .HasOne(wa => wa.Employee)
                .WithMany(employee => employee.WarrantAllocations)
                .HasForeignKey(wa => wa.EmployeeId);
        });
        
        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa1"),
                Cpr = "0101010001",
                FullName = "Alice Andersen",
                Email = "alice@example.com",
                Address = "1 Main Street",
                PhoneNumber = "12345678"
            },
            new Employee
            {
                Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa2"),
                Cpr = "0202020002",
                FullName = "Bob Bentsen",
                Email = "bob@example.com",
                Address = "2 Main Street",
                PhoneNumber = "23456789"
            },
            new Employee
            {
                Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3"),
                Cpr = "0303030003",
                FullName = "Clara Christensen",
                Email = "clara@example.com",
                Address = "3 Main Street",
                PhoneNumber = "34567890"
            },
            new Employee
            {
                Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4"),
                Cpr = "0404040004",
                FullName = "David Dahl",
                Email = "david@example.com",
                Address = "4 Main Street",
                PhoneNumber = "45678901"
            }
        );
    }
}