using Employee_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_Project.ViewModels
{
    public class EmployeeListViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}
