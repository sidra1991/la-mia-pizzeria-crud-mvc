﻿using la_mia_pizzeria_static.data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {

        PizzaDB db;

        public PizzaController() : base()
        {
            db = new PizzaDB();
        }


        public IActionResult Index()
        {
            List<Pizza> pizzaList = db.pizze.ToList();

            return View("Index", pizzaList);
        }

        public IActionResult Show(int id)
        {

            Pizza pizza = db.pizze.Where(p => p.Id == id).FirstOrDefault();

            return View(pizza);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            db.pizze.Add(pizza);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Pizza pizza = db.pizze.Where(Pizza => Pizza.Id == id).FirstOrDefault();

            if (pizza == null)
                return NotFound();


            return View("Update", pizza );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Pizza formData)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            Pizza pizza = db.pizze.Where(post => post.Id == id).FirstOrDefault();

            if (pizza == null)
            {
                return NotFound();
            }

            pizza.Name = formData.Name;
            pizza.Description = formData.Description;
            pizza.ImageAddress = formData.ImageAddress;
            pizza.Price = formData.Price;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Pizza pizza = db.pizze.Where(post => post.Id == id).FirstOrDefault();

            if (pizza == null)
            {
                return NotFound();
            }

            db.pizze.Remove(pizza);
            db.SaveChanges();


            return RedirectToAction("Index");
        }

    }
}
