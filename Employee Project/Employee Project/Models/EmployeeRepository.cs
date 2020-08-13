using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace Employee_Project.Models
{
    public class EmployeeRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Employee> employees = new List<Employee>();

        public EmployeeRepository()
        {
            employees = cache["employees"] as List<Employee>;
            if (employees == null)
            {
                employees = new List<Employee>();
            }
        }
        public void Commit()
        {
            cache["employees"] = employees;
        }

        public void Insert(Employee p)
        {
            employees.Add(p);
        }

        public void Update(Employee employee)
        {
            Employee empToUpdate = employees.Find(p => p.EmpId == employee.EmpId);

            if (empToUpdate != null)
            {
                empToUpdate = employee;
            }
            else
            {
                throw new Exception("employee not found");
            }
        }
        public Employee Find(string Id)
        {
            Employee employee = employees.Find(p => p.EmpId == Id);
            if (employee != null)
            {
                return employee;
            }
            else
            {
                throw new Exception("employee not found");
            }

        }
    }
}