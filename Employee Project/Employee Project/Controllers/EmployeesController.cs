using Employee_Project.Models;
using Employee_Project.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Employee_Project.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeContext db = new EmployeeContext();
        
        
        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            EmployeesViewModel viewModel = new EmployeesViewModel();
            viewModel.employee = new Employee();
            viewModel.employeeDepartments = db.EmployeeDepartments.ToList();
            return View(viewModel);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpId,Name,Address,Department")] Employee employee, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            else
            {
                if (file != null)
                {
                    employee.Image = employee.EmpId + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ProductImages//") + employee.Image);
                }
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            
        }
    
            

        // GET: Employees/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                
             return HttpNotFound();
                    
            }
            else
            {
                EmployeesViewModel viewModel = new EmployeesViewModel();
                viewModel.employee = employee;
                viewModel.employeeDepartments = db.EmployeeDepartments.ToList();
                return View(viewModel);
            }
                
           
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpId,Name,Address,Department")] Employee employee, string Id, HttpPostedFileBase file)
        {
            Employee employeeToEdit = db.Employees.Find(Id);
             if (employeeToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(employee);
                }
                if (file != null)
                {
                    employeeToEdit.Image = employeeToEdit.EmpId + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ProductImages//") + employeeToEdit.Image);
                }
                employeeToEdit.Name = employee.Name;
                employeeToEdit.Address = employee.Address;
                employeeToEdit.Department = employee.Department;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }

        

        // GET: Employees/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
