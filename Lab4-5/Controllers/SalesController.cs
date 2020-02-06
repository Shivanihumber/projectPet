using Lab4_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4_5.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            ViewBag.Message = "Your contact page.";
            Models.PetContext petContext = new Models.PetContext();
            List<Models.Sales> Sales = petContext.Sales.ToList();

            return View(Sales);
        }
        [HttpGet]
        public ActionResult Add(int SaleId = 0)
        {

            Sales sale = new Sales();
            // Customer customer = new Customer();

            PetContext petContext = new PetContext();
            sale.Customers = petContext.Customers.ToList();
            sale.Pets = petContext.Pets.ToList();


            return View(sale);

        }
    }
}