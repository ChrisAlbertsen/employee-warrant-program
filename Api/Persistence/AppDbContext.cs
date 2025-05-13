using System;
using System.Collections.Generic;
using BlazorApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace Api.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) {
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Case> Cases { get; set; }
    public DbSet<WarrantAllocation> WarrantAllocations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Employee>().HasData(
            new List<Employee>
        {
            new Employee
            {
                Id = Guid.NewGuid(),
                Cpr = "123456-0000",
                FullName = "Anna Pihl",
                Email = "anna.sorensen@example.com",
                Address = "Langelinie Allé 17, 2100 København Ø",
                PhoneNumber = "+45 22 33 44 55"
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                Cpr = "150482-5678",
                FullName = "Mikkel Hansen",
                Email = "mikkel.hansen@example.com",
                Address = "Vesterbrogade 100, 1620 København V",
                PhoneNumber = "+45 40 55 66 77"
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                Cpr = "230375-4321",
                FullName = "Camilla Jensen",
                Email = "camilla.jensen@example.com",
                Address = "Åboulevard 39, 1960 Frederiksberg C",
                PhoneNumber = "+45 31 22 11 00"
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                Cpr = "071291-8765",
                FullName = "Jonas Nielsen",
                Email = "jonas.nielsen@example.com",
                Address = "Havneholmen 29, 1561 København V",
                PhoneNumber = "+45 50 60 70 80"
            }
        });
    }
    
    
}