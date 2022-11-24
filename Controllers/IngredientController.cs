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
            if (db.Ingredientes.ToList().Count > 0)
            {
                List<Ingredient> ingredients = db.Ingredientes.ToList();
                return View("Indexingred", ingredients);
            }
            else
            {
                List<Ingredient> ingredients = new List<Ingredient>();
                return View("Indexingred", ingredients);
            }
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ingredient ingredients)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Ingredient Newingredients = ingredients;

            db.Ingredientes.Add(Newingredients);
            db.SaveChanges();

            return RedirectToAction("Indexingred");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Ingredient ingredients)
        {

            if (!ModelState.IsValid)
            {
                return View("Indexingred");
            }

            Ingredient Newingredients = db.Ingredientes.Where(ing => ing.Id == id).FirstOrDefault();

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
            Ingredient ingredients = db.Ingredientes.Where(cat => cat.Id == id).FirstOrDefault();

            if (ingredients == null)
            {
                return NotFound();
            }

            db.Ingredientes.Remove(ingredients);
            db.SaveChanges();


            return RedirectToAction("Indexingred");
        }
    }
}
