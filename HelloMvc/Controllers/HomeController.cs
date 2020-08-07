using HelloMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Runtime.Caching;

namespace HelloMvc.Controllers
{
    public class HomeController : Controller
    {
        ObjectCache cache = MemoryCache.Default;

        List<Customer> customers;

        // Constructor
        public HomeController()
        {
            customers = cache["customers"] as List<Customer>;
            if(customers==null)
            {
                customers = new List<Customer>();
            }
            
        }

        // SaveCache Method
        public void SaveCache()
        {
            cache["customers"] = customers;
        }

        // Default Index Action Method
        public ActionResult Index()
        {
            return View();
        }

        // About Action Method
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.MysuperProperty = " This is my first app!";
            return View();
        }

        // Contact Action Method
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // ViewCustomer Action Method
        public ActionResult ViewCustomer(string id)
        {
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if(customer==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
            
        }

        // AddCustomer Action Method HttpGet
        public ActionResult AddCustomer()
        {
            return View();
        }

        // AddCustomer Action Method Httppost
        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return View(customer);
            }
            customer.Id = Guid.NewGuid().ToString();
            customers.Add(customer);
            SaveCache();
            return RedirectToAction("CustomerList");
        }

        // EditCustomer Action Method Getter
        public ActionResult EditCustomer(String id)
        {
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }

        }
        [HttpPost]
        public ActionResult EditCustomer(Customer customer,string Id)
        {
            Customer customerToEdit = customers.FirstOrDefault(c => c.Id == Id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                customerToEdit.Name = customer.Name;
                customerToEdit.Telephone = customer.Telephone;
                SaveCache();
                return RedirectToAction("CustomerList");
            }

        }
        
        public ActionResult DeleteCustomer(string Id)
        {
            Customer customer = customers.FirstOrDefault(c => c.Id == Id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
               
                return View(customer);
            }
        }

        [HttpPost]
        [ActionName("DeleteCustomer")]
        public ActionResult DeleteCustomer(Customer customer,string Id)
        {
            Customer customerToDelete = customers.FirstOrDefault(c => c.Id == Id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                customers.Remove(customerToDelete);
                return RedirectToAction("CustomerList");
            }
        }

       

         public ActionResult SearchCustomer(string searchstr)
         {
            Customer customer = customers.FirstOrDefault(c => c.Name == searchstr);
            if (!String.IsNullOrEmpty(searchstr))
                {
                    customers = customers.Where(s => s.Name.Contains(searchstr)).ToList();
                }
            return View(customer);
            
         }

        public ActionResult CustomerList()
        { 
            return View(customers);
        }
    }


}