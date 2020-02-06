using Lab4_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4_5.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            ViewBag.Message = "Your contact page.";
            Models.PetContext petContext = new Models.PetContext();
            List<Models.Customer> customers = petContext.Customers.ToList();

            return View(customers);
        }
        [HttpGet]
        public ActionResult Add(int CustomerId = 0)
        {
            return View(new Models.Customer());

        }
        [HttpPost]
        public ActionResult Add(FormCollection formCollection)
        {
            Customer customer = new Customer();
            PetContext petContext = new PetContext();
            customer.Name= formCollection["Name"];
            customer.Address = formCollection["Address"];
            customer.TelephoneNo = formCollection["TelephoneNo"];
            customer.Email = formCollection["Email"];

            petContext.Customers.Add(customer);
            petContext.SaveChanges();
            return RedirectToAction("Index", new { id = customer.CustomerId });

        }
        public ActionResult Delete(int id)
        {

            PetContext petContext = new PetContext();
            Customer customer = petContext.Customers.Find(id);
            petContext.Customers.Remove(customer);
            petContext.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            Customer customer = new Customer();
         
            PetContext petContext = new PetContext();
            customer = petContext.Customers.Where(x => x.CustomerId== id).FirstOrDefault();
            return View(customer);
        }




        [HttpGet]
        public ActionResult Edit(int id)
        {


            Customer customer = new Customer();
            PetContext petContext = new PetContext();
            customer = petContext.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection formCollection,int id)
        {


            Customer customer = new Customer();
            PetContext petContext = new PetContext();
           customer = petContext.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
            customer.Name = formCollection["Name"];
            customer.Address = formCollection["Address"];
            customer.TelephoneNo = formCollection["TelephoneNo"];
            customer.Email = formCollection["Email"];
            
            petContext.SaveChanges();

            return RedirectToAction("Index", customer);
        }


    }
}

