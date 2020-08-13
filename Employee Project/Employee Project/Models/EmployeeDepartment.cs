using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employee_Project.Models
{
    public class EmployeeDepartment
    {
        [Key]
        public string DeptId { get; set; }
        
        public string Department { get; set; }
        public EmployeeDepartment()
        {
            this.DeptId = Guid.NewGuid().ToString();
        }
    }
}