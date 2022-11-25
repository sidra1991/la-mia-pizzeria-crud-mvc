﻿using la_mia_pizzeria_static.Controllers.Repository;
using la_mia_pizzeria_static.data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;


namespace la_mia_pizzeria_static.Controllers
{
    public class IngredientController : Controller
    {
        DbPizzaRepository db;
        public IngredientController() : base()
        {
            db = new DbPizzaRepository();
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
        public IActionResult Create(Ingredient ingredients)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Ingredient Newingredients = ingredients;

            db.AddIngredient(Newingredients);
            db.Save();

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

            db.ThisIngredient(id).Name = ingredients.Name;
            db.Save();

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

            db.RemoveIngredient(db.ThisIngredient(id));
            db.Save();


            return RedirectToAction("Indexingred");
        }
    }
}
