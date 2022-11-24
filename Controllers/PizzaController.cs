using Azure;
using la_mia_pizzeria_static.data;
using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.SqlServer.Server;
using Ingredient = la_mia_pizzeria_static.Models.Ingredient;

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
            if(db.Pizze.ToList().Count > 0) {
                List<Pizza> pizzaList = db.Pizze.ToList();
                return View("Index", pizzaList);
            }
            else
            {
                List<Pizza> pizzaList = new List<Pizza>();
                return View("Index", pizzaList);
            }
            
            
        }

        public IActionResult Show(int id)
        {

            Pizza pizza = db.Pizze.Where(p => p.Id == id).FirstOrDefault();

            return View(pizza);
        }

        public IActionResult Create()
        {
            PizzaForm forms = new PizzaForm();  
            forms.Pizza = new Pizza();
            forms.Categories = db.Categoryes.ToList();
            forms.Ingredients = db.Ingredientes.ToList();
            //forms.Ingredients = new List<SelectListItem>();


            //List<Ingredient> Ingredients = db.Ingredientes.ToList();

            //foreach (Ingredient ingr in Ingredients)
            //{
            //    Ingredient ingredient = (Ingredient)db.Ingredientes.Where(i => i.Id == ingr.Id);
            //    forms.Ingredients.Add(ingredient);
            //}



            return View("Create",forms);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaForm forms)
        {
            if (!ModelState.IsValid)
            {
                forms.Categories = db.Categoryes.ToList();
                forms.Ingredients = new List<Ingredient>();

                List<Ingredient> Ingredients = db.Ingredientes.ToList();

                foreach (Ingredient ingr in Ingredients)
                {
                    Ingredient ingredient = db.Ingredientes.Where(i => i.Id == ingr.Id).FirstOrDefault();
                    forms.Ingredients.Add(ingredient);
                }

                return View(forms);
            }

            forms.Pizza.Ingredients = new List<Ingredient>();

            foreach (int ing in forms.SelectIngredient)
            {
                Ingredient ingred = db.Ingredientes.Where(i => i.Id == ing).FirstOrDefault();
                forms.Pizza.Ingredients.Add(ingred);
            }


            db.Pizze.Add(forms.Pizza);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Pizza pizza = db.Pizze.Where(Pizza => Pizza.Id == id).FirstOrDefault();

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

            Pizza pizza = db.Pizze.Where(post => post.Id == id).Include("Category").FirstOrDefault();

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
            Pizza pizza = db.Pizze.Where(piz => piz.Id == id).FirstOrDefault();

            if (pizza == null)
            {
                return NotFound();
            }

            db.Pizze.Remove(pizza);
            db.SaveChanges();


            return RedirectToAction("Index");
        }

    }
}
