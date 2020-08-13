using Employee_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_Project.ViewModels
{
    public class EmployeesViewModel
    {
        public Employee employee { get; set; }
        public IEnumerable<EmployeeDepartment> employeeDepartments { get; set; }
    }
}