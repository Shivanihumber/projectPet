using Lab4_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4_5.Controllers
{
    public class PetsController : Controller
    {
        // GET: Pets
        public ActionResult Index()
        {
            ViewBag.Message = "Your contact page.";
            Models.PetContext petContext = new Models.PetContext();
            List<Models.Pet> Pets = petContext.Pets.ToList();
            return View(Pets);
        }
        [HttpGet]
        public ActionResult Add(int PetId = 0)
        {
            Pet pet = new Pet();

            PetContext petContext = new PetContext();
            
            pet.Categories = petContext.Categories.ToList();

            pet.Category = pet.Categories.First();
            return View(pet);

        }
        [HttpPost]
        public ActionResult Add(FormCollection formCollection)
        {
           Pet pet = new Pet();
           
            PetContext petContext = new PetContext();
            String str = formCollection["Birthdate"];

            pet.Birthdate = Convert.ToDateTime(formCollection["Birthdate"]);
            pet.Gender = formCollection["Gender"];
            pet.Price = Convert.ToDecimal(formCollection["Price"]);
            pet.Category = petContext.Categories.Find(Convert.ToInt32(formCollection["CategoryId"]));

            petContext.Pets.Add(pet);
          
            petContext.SaveChanges();
            return RedirectToAction("Index", new { id = pet.PetId });

        }
        public ActionResult Delete(int id)
        {

            PetContext petContext = new PetContext();
            Pet pet = petContext.Pets.Find(id);
            petContext.Pets.Remove(pet);
            petContext.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            PetContext petContext = new PetContext();
            Pet pet = petContext.Pets.Find(id);
            return View(pet);
        }




        [HttpGet]
        public ActionResult Edit(int id)
        {

            Pet pet = new Pet();
            PetContext petContext = new PetContext();
            pet = petContext.Pets.Where(x => x.PetId == id).FirstOrDefault();
            pet.Categories = petContext.Categories.ToList();
            return View(pet);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection formCollection,int id)
        {

            Pet pet = new Pet();
            PetContext petContext = new PetContext();


            pet = petContext.Pets.Where(x => x.PetId == id).FirstOrDefault();
            pet.Birthdate = Convert.ToDateTime(formCollection["Birthdate"]);
            pet.Gender = formCollection["Gender"];
            pet.Price = Convert.ToDecimal(formCollection["Price"]);
            pet.Category = petContext.Categories.Find(Convert.ToInt32(formCollection["CategoryId"]));

        

            petContext.SaveChanges();
            return RedirectToAction("Index",pet);
          
        }

    }
}

