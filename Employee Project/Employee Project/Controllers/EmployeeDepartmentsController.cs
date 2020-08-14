using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Employee_Project.Models;

namespace Employee_Project.Controllers
{
    public class EmployeeDepartmentsController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: EmployeeDepartments
        //testing
        public ActionResult Index()
        {
            return View(db.EmployeeDepartments.ToList());
        }

        // GET: EmployeeDepartments/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDepartment employeeDepartment = db.EmployeeDepartments.Find(id);
            if (employeeDepartment == null)
            {
                return HttpNotFound();
            }
            return View(employeeDepartment);
        }

        // GET: EmployeeDepartments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeDepartments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Department")] EmployeeDepartment employeeDepartment)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeDepartments.Add(employeeDepartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeDepartment);
        }

        // GET: EmployeeDepartments/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDepartment employeeDepartment = db.EmployeeDepartments.Find(id);
            if (employeeDepartment == null)
            {
                return HttpNotFound();
            }
            return View(employeeDepartment);
        }

        // POST: EmployeeDepartments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeptId,Department")] EmployeeDepartment employeeDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeDepartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeDepartment);
        }

        // GET: EmployeeDepartments/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDepartment employeeDepartment = db.EmployeeDepartments.Find(id);
            if (employeeDepartment == null)
            {
                return HttpNotFound();
            }
            return View(employeeDepartment);
        }

        // POST: EmployeeDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EmployeeDepartment employeeDepartment = db.EmployeeDepartments.Find(id);
            db.EmployeeDepartments.Remove(employeeDepartment);
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
