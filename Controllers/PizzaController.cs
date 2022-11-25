using Azure;
using la_mia_pizzeria_static.Controllers.Repository;
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

        DbPizzaRepository repository;

        public PizzaController() : base()
        {
            repository = new DbPizzaRepository();
        }



        // index
        // restituisce la view index con la lista delle pizze nel DB
        public IActionResult Index()
        {
            List<Pizza> pizzaList;
            if(repository.ListPizze().Count > 0) {
                return View(repository.ListPizze());
            }
            else
            {
                return View( new List<Pizza>());
            }
        }

        //show
        // si occupa di fornire i dettagli delle pizze
        public IActionResult Show(int id)
        {
            return View(repository.TihisPizza(id));
        }

        //crerate
        //2 funzioni
        // si occupa di creare una nuova pizza nel DB
        public IActionResult Create()
        {
            PizzaForm forms = new PizzaForm();  
            forms.Pizza = new Pizza();
            forms.Categories = repository.ListCategory();
            forms.Ingredients = repository.ListIngredient();

            return View("Create",forms);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaForm forms)
        {
            if (!ModelState.IsValid)
            {
                forms.Categories = repository.ListCategory();
                forms.Ingredients = new List<Ingredient>();
                List<Ingredient> Ingredients = repository.ListIngredient();
                foreach (Ingredient ingr in Ingredients)
                {
                    forms.Ingredients.Add(repository.ThisIngredient(ingr.Id));
                }

                return View(forms);
            }

            forms.Pizza.Ingredients = new List<Ingredient>();

            foreach (int ing in forms.SelectIngredient)
            {
                forms.Pizza.Ingredients.Add(repository.ThisIngredient(ing));
            }


            repository.AddPizza(forms.Pizza);
            repository.Save();

            return RedirectToAction("Index");
        }

        //update
        // 2 funzioni
        // si occupa di modificare i dati nel DB riguardo una pizza
        public IActionResult Update(int id)
        {
            Pizza pizza = repository.TihisPizza(id);

            if (pizza == null)
                return NotFound();

            PizzaForm forms = new();
            forms.Pizza = pizza;
            forms.Categories = repository.ListCategory();
            forms.Ingredients = new List<Ingredient>();

            List<Ingredient> Ingredients = repository.ListIngredient();

            foreach (Ingredient ingr in Ingredients)
            {
                Ingredient ingredient = repository.ThisIngredient(ingr.Id);
                forms.Ingredients.Add(ingredient);
            }

            return View("Update", pizza );
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaForm forms)
        {

            if (!ModelState.IsValid)
            {
                forms.Categories = repository.ListCategory();
                forms.Ingredients = new List<Ingredient>();

                List<Ingredient> Ingredients = repository.ListIngredient();

                foreach (Ingredient ingr in Ingredients)
                {
                    Ingredient ingredient = repository.ThisIngredient(ingr.Id);
                    forms.Ingredients.Add(ingredient);
                }
                return View();
            }

            Pizza pizza = repository.TihisPizza(id);

            if (pizza == null)
            {
                return NotFound();
            }

            pizza.Name = forms.Pizza.Name;
            pizza.Description = forms.Pizza.Description;
            pizza.ImageAddress = forms.Pizza.ImageAddress;
            pizza.Price = forms.Pizza.Price;
            forms.Pizza.Ingredients = new List<Ingredient>();

            foreach (int ing in forms.SelectIngredient)
            {
                Ingredient ingred = repository.ThisIngredient(ing);
                forms.Pizza.Ingredients.Add(ingred);
            }

            repository.Save();

            return RedirectToAction("Index");
        }

        //delete
        //elimina una pizza daL DB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Pizza pizza = repository.TihisPizza(id);

            if (pizza == null)
            {
                return NotFound();
            }

            repository.RemovePizza(pizza);
            repository.Save();


            return RedirectToAction("Index");
        }

    }
}
