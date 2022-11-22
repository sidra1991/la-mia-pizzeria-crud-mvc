using la_mia_pizzeria_static.data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;


namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {

        public IActionResult Index()
        {
            PizzaDB pi = new PizzaDB();

            List<Pizza> pizzaList = pi.pizze.ToList();

            return View("Index", pizzaList);
        }

        public IActionResult Show(int id)
        {
            PizzaDB pi = new PizzaDB();

            Pizza pizza = pi.pizze.Where(p => p.Id == id).FirstOrDefault();

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
            PizzaDB pi = new PizzaDB();

            if (!ModelState.IsValid)
            {
                return View();
            }


            pi.pizze.Add(pizza);
            pi.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
