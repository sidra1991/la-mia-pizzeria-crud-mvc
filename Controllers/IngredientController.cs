using la_mia_pizzeria_static.data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class IngredientController : Controller
    {
        PizzaDB db;
        public IngredientController() : base()
        {
            db = new PizzaDB();
        }
        public IActionResult Indexingred()
        {
            if (db.ingredientes.ToList().Count > 0)
            {
                List<ingredient> ingredients = db.ingredientes.ToList();
                return View("Indexingred", ingredients);
            }
            else
            {
                List<ingredient> ingredients = new List<ingredient>();
                return View("Indexingred", ingredients);
            }
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ingredient ingredients)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ingredient Newingredients = ingredients;

            db.ingredientes.Add(Newingredients);
            db.SaveChanges();

            return RedirectToAction("Indexingred");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, ingredient ingredients)
        {

            if (!ModelState.IsValid)
            {
                return View("Indexingred");
            }

            ingredient Newingredients = db.ingredientes.Where(ing => ing.Id == id).FirstOrDefault();

            if (ingredients == null)
            {
                return NotFound();
            }

            Newingredients.Name = ingredients.Name;


            db.SaveChanges();

            return RedirectToAction("Indexingred");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            ingredient ingredients = db.ingredientes.Where(cat => cat.Id == id).FirstOrDefault();

            if (ingredients == null)
            {
                return NotFound();
            }

            db.ingredientes.Remove(ingredients);
            db.SaveChanges();


            return RedirectToAction("Indexingred");
        }
    }
}
