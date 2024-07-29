using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDep.Entitys
{
    public class Employee
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int? ChiefId { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public Department Department { get; set; }
        public Employee Chief { get; set; }
        public ICollection<Employee> Subordinates { get; set; }
    }
}
