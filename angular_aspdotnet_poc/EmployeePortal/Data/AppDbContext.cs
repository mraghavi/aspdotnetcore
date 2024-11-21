﻿using Microsoft.EntityFrameworkCore;
using EmployeePortal.Models;

namespace EmployeePortal.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 

        
        }

        // Define DbSet for each entity
        public DbSet<Employee> Employees { get; set; }
    }
}
