using DataDep.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDep.Context
{
    public class OurDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Замените строку подключения на вашу собственную
            optionsBuilder.UseSqlServer("Server=WIN-7L0UJ4EFJQC;Database=DataDep;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "D1" },
                new Department { Id = 2, Name = "D2" },
                new Department { Id = 3, Name = "D3" });

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, DepartmentId = 1, ChiefId = 5, Name = "John", Salary = 100 },
                new Employee { Id = 2, DepartmentId = 1, ChiefId = 5, Name = "Misha", Salary = 600 },
                new Employee { Id = 3, DepartmentId = 2, ChiefId = 6, Name = "Eugen", Salary = 300 },
                new Employee { Id = 4, DepartmentId = 2, ChiefId = 6, Name = "Tolya", Salary = 400 },
                new Employee { Id = 5, DepartmentId = 3, ChiefId = 7, Name = "Stepan", Salary = 500 },
                new Employee { Id = 6, DepartmentId = 3, ChiefId = 7, Name = "Alex", Salary = 1000 },
                new Employee { Id = 7, DepartmentId = 3, ChiefId = null, Name = "Ivan", Salary = 1100 });
        }
    }
}
