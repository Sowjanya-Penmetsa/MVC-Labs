using Employee_Project.Models;
using Employee_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_Project.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeContext db = new EmployeeContext();
        public ActionResult Index(string Department = null)
        {
            List<Employee> Employees;
            List<EmployeeDepartment> Departments = db.EmployeeDepartments.ToList();
            if (Department == null)
            {
                Employees = db.Employees.ToList();
            }
            else
            {
                Employees = db.Employees.ToList().Where(p => p.Department == Department).ToList();
            }
            EmployeeListViewModel model = new EmployeeListViewModel();
            model.Employees = Employees;
            model.EmployeeDepartments = Departments;
            return View(model);
        }

        public ActionResult Details(string EmpId)
        {
            Employee employee = db.Employees.Find(EmpId);
            if (employee == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(employee);
            }
        }


    }
}
