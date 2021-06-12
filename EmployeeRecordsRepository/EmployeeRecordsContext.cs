using EmployeeRecordsDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeRecordsRepository
{

    public sealed class EmployeeRecordsContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Employee> Employees { get; set; }

        public EmployeeRecordsContext(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("ConnectionString needed");

            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder
                .UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(a =>
            {
                a.ToTable("Employee").HasKey(b => b.Id);
                a.OwnsOne(b => b.Name, b =>
                {
                    b.Property(pp => pp.First).HasColumnName("FirstName");
                    b.Property(pp => pp.Middle).HasColumnName("MiddleName");
                    b.Property(pp => pp.Last).HasColumnName("LastName");
                });
            });
        }
    }
}
