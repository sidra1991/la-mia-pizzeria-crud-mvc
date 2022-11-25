using la_mia_pizzeria_static.Controllers.Repository;
using la_mia_pizzeria_static.data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;


namespace la_mia_pizzeria_static.Controllers
{
    public class IngredientController : Controller
    {
        InerfacePizzaRepository db;
        public IngredientController(InerfacePizzaRepository _repository) : base()
        {
            db = _repository;
        }

        //index
        //restituisce una lista di ingredienti in fase di gestione 
        public IActionResult Indexingred()
        {
            if (db.ListIngredient().Count > 0)
            {
                return View(db.ListIngredient());
            }
            else
            {
                return View(new List<Ingredient>());
            }
        }

        //create
        //si occupa di creare un nuovo ingrediente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ingredient ingredient)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            db.AddIngredient(ingredient);

            return RedirectToAction("Indexingred");
        }

        //update
        //si occupa di modificare un ingrediente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Ingredient ingredients)
        {

            if (!ModelState.IsValid)
            {
                return View("Indexingred");
            }

            if (ingredients == null)
            {
                return NotFound();
            }

            db.UpdateIngredient( id, ingredients);

            return RedirectToAction("Indexingred");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (db.ThisIngredient(id) == null)
            {
                return NotFound();
            }

            db.RemoveIngredient(id);

            return RedirectToAction("Indexingred");
        }
    }
}
