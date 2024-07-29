using DataDep;
using DataDep.Context;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new OurDbContext())
        {
            // 1. Суммарная зарплата в разрезе департаментов (без руководителей и с руководителями)
            var totalSalariesWithChiefs = context.Departments
                .Select(d => new
                {
                    Department = d.Name,
                    TotalSalary = d.Employees.Sum(e => e.Salary)
                });

            var totalSalariesWithoutChiefs = context.Departments
                .Select(d => new
                {
                    Department = d.Name,
                    TotalSalary = d.Employees.Where(e => e.ChiefId == null).Sum(e => e.Salary)
                });

            Console.WriteLine("Суммарная зарплата с начальниками:");
            foreach (var item in totalSalariesWithChiefs)
            {
                Console.WriteLine($"Департамент: {item.Department}, Суммарная зарплата: {item.TotalSalary}");
            }

            Console.WriteLine("\nСуммарная зарплата без начальников:");
            foreach (var item in totalSalariesWithoutChiefs)
            {
                Console.WriteLine($"Департамент: {item.Department}, Суммарная зарплата: {item.TotalSalary}");
            }

            // 2. Департамент, в котором у сотрудника зарплата максимальна
            var departmentWithMaxSalary = context.Employees
                .OrderByDescending(e => e.Salary)
                .Select(e => e.Department.Name)
                .FirstOrDefault();

            Console.WriteLine($"\nДепартамент с сотрудником с самой высокой зарплатой: {departmentWithMaxSalary}");

            // 3. Зарплаты руководителей департаментов (по убыванию)
            var chiefSalaries = context.Employees
                .Where(e => context.Employees.Select(c => c.ChiefId).Contains(e.Id))
                .OrderByDescending(e => e.Salary)
                .Select(e => new { e.Name, e.Salary });

            Console.WriteLine("\nЗарплаты начальников департаментов по убыванию:");
            foreach (var chief in chiefSalaries)
            {
                Console.WriteLine($"Начальник: {chief.Name}, Зарплата: {chief.Salary}");
            }
        }
    }
}