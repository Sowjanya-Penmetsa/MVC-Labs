using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employee_Project.Models
{
    public class Employee
    {
        [Key]
        public string EmpId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Image { get; set; }
        public Employee()
        {
            this.EmpId = Guid.NewGuid().ToString();
        }
    }
}