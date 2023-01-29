﻿using Microsoft.EntityFrameworkCore;

namespace MVCD2.Models
{
    public class companyContext : DbContext
    {

        public companyContext()
        {

        }
        public companyContext(DbContextOptions option) : base(option) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-KBA9C6N\\SS16;Initial Catalog=company;Integrated Security=True;TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<location>().HasKey("DeptNumber", "Location");
            modelBuilder.Entity<workOn>().HasKey("ESSN", "projectNum");
            modelBuilder.Entity<employee>().HasOne(s => s.SuperVisor).WithMany(s => s.Employees);
            modelBuilder.Entity<Department>().HasOne(d => d.employee).WithOne(e => e.Department);
            modelBuilder.Entity<Department>().HasMany(d => d.employees).WithOne(e => e.Department2);

        }
        public DbSet<Department> departments { get; set; }
        public DbSet<employee> employees { get; set; }
        public DbSet<dependents> dependents { get; set; }
        public DbSet<location> locations { get; set; }
        public DbSet<project> projects { get; set; }
        public DbSet<workOn> workOns { get; set; }
    }
}