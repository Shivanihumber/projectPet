using Lab4_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4_5.Controllers
{
    public class CategoryController : Controller
    {


        public ActionResult Index()
        {
            ViewBag.Message = "Your contact page.";
            Models.PetContext petContext = new Models.PetContext();
            List<Models.Category> categories = petContext.Categories.ToList();

            return View(categories);

        }
        [HttpGet]
        public ActionResult Add(int CategoryId = 0)
        {
return View(new Models.Category());
 }
        [HttpPost]
        public ActionResult Add(FormCollection formCollection)
        {
            Category category = new Category();
            PetContext petContext = new PetContext();
            category.CategoryName = formCollection["CategoryName"];

            petContext.Categories.Add(category);
            petContext.SaveChanges();
            return RedirectToAction("Index", new { id = category.CategoryName });

        }

        public ActionResult Delete(int CategoryId)
        {
          
            PetContext petContext = new PetContext();
            Category category = petContext.Categories.Find(CategoryId);
            petContext.Categories.Remove(category);
            petContext.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Detail(int CategoryId)
        {

            Category category = new Category();
            PetContext petContext = new PetContext();
           category = petContext.Categories.Where(x => x.CategoryId == CategoryId).FirstOrDefault();
           return View(category);
        }

        
    

        [HttpGet]
        public ActionResult Edit(int CategoryId)
        {

          
            Category category = new Category();
            PetContext petContext = new PetContext();
            category = petContext.Categories.Where(x => x.CategoryId == CategoryId).FirstOrDefault();
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection formCollection,int CategoryId)
        {


            Category category = new Category();
            PetContext petContext = new PetContext();
            category = petContext.Categories.Where(x => x.CategoryId == CategoryId).FirstOrDefault();
            category.CategoryName = formCollection["CategoryName"];

        
            petContext.SaveChanges();
            return RedirectToAction("Index", category);

          
        }


    }
}