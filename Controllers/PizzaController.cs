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
            if(db.pizze.ToList().Count > 0) {
                List<Pizza> pizzaList = db.pizze.ToList();
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

            Pizza pizza = db.pizze.Where(p => p.Id == id).FirstOrDefault();

            return View(pizza);
        }

        public IActionResult Create()
        {
            PizzaForm forms = new PizzaForm();  
            forms.Pizza = new Pizza();
            forms.categories = db.categoryes.ToList();
            forms.ingredients = new List<SelectListItem>();


            List<Ingredient> ingredients = db.ingredientes.ToList();

            foreach (Ingredient ingr in ingredients)
            {
                forms.ingredients.Add(new SelectListItem(ingr.Name, ingr.Id.ToString()));
            }



            return View("Create",forms);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaForm forms)
        {
            if (!ModelState.IsValid)
            {
                forms.categories = db.categoryes.ToList();
                forms.ingredients = new List<SelectListItem>();

                List<Ingredient> tagList = db.ingredientes.ToList();

                foreach (Ingredient tag in tagList)
                {
                    forms.ingredients.Add(new SelectListItem(tag.Name, tag.Id.ToString()));
                }

                return View(forms);
            }

            forms.Pizza.ingredients = new List<Ingredient>();

            foreach (int tagId in forms.selectIngredient)
            {
                Ingredient ingredient = db.ingredientes.Where(t => t.Id == tagId).FirstOrDefault();
                forms.Pizza.ingredients.Add(ingredient);
            }


            db.pizze.Add(forms.Pizza);
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

            Pizza pizza = db.pizze.Where(post => post.Id == id).Include("Category").FirstOrDefault();

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
            Pizza pizza = db.pizze.Where(piz => piz.Id == id).FirstOrDefault();

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
