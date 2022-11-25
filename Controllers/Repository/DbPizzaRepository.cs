using la_mia_pizzeria_static.data;
using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using static la_mia_pizzeria_static.Controllers.Repository.DbPizzaRepository;

namespace la_mia_pizzeria_static.Controllers.Repository
{
    public class DbPizzaRepository : InerfacePizzaRepository
    {
        private PizzaDB db;

        public DbPizzaRepository()
        {
            db = new PizzaDB();
        }


        //funzioni DB per pizza
        public Pizza TihisPizza(int id)
        {
            return db.Pizze.Where(Pizza => Pizza.Id == id).Include("Category").Include("Ingredients").FirstOrDefault();
        }
        public List<Pizza> ListPizze()
        {
            return db.Pizze.ToList();
        }
        public void AddPizza(PizzaForm forms , List<Ingredient> ingredients)
        {
            Pizza newPizza = forms.Pizza;
            newPizza.Category = ThisCategory(forms.Pizza.CategoryId);
            newPizza.Ingredients = new();
            foreach (var item in ingredients)
            {
                newPizza.Ingredients.Add(item);
            }
            newPizza.CategoryId = forms.Pizza.CategoryId;
            db.Pizze.Add(newPizza);
            db.SaveChanges();
        }
        public void RemovePizza(Pizza pizza)
        {
            
            db.Pizze.Remove(pizza);
            db.SaveChanges();
        }
        public void UploadPizza(PizzaForm forms)
        {
            Pizza uploadPizza = TihisPizza(forms.Pizza.Id);
            uploadPizza.Ingredients = new List<Ingredient>();

            foreach (int ing in forms.SelectIngredient)
            {
                uploadPizza.Ingredients.Add(ThisIngredient(ing));
            }
            uploadPizza.Name = forms.Pizza.Name;
            uploadPizza.Description = forms.Pizza.Description;
            uploadPizza.ImageAddress = forms.Pizza.ImageAddress;
            uploadPizza.Price = forms.Pizza.Price;
            uploadPizza.Category = forms.Pizza.Category;
            uploadPizza.CategoryId = forms.Pizza.CategoryId;
            db.Pizze.Update(uploadPizza); 
            db.SaveChanges();
        }


        //funzioni DB per ingredienti
        public Ingredient ThisIngredient(int id)
        {
            return db.Ingredientes.Where(i => i.Id == id).Include("Pizzas").FirstOrDefault();
        }
        public List<Ingredient> ListIngredient()
        {
            return db.Ingredientes.ToList();
        }
        public void AddIngredient(Ingredient ingredient)
        {
            db.Ingredientes.Add(ingredient);
            db.SaveChanges();
        }
        public void RemoveIngredient(int id)
        {
            db.Ingredientes.Remove(ThisIngredient(id));
            db.SaveChanges();
        }
        public void UpdateIngredient(int id,Ingredient ingredient)
        {
            ThisIngredient(id).Name = ingredient.Name;
            db.SaveChanges();
        }

        //funzioni DB per category
        public Category ThisCategory(int id)
        {
            return db.Categoryes.Where(post => post.Id == id).FirstOrDefault();
        }
        public List<Category> ListCategory()
        {
            return db.Categoryes.ToList();
        }
        public void AddCategory(Category category)
        {
            db.Categoryes.Add(category);
            db.SaveChanges();
        }
        public void UpdateCategory(int id,Category category)
        {
            ThisCategory(id).Name = category.Name;
            db.SaveChanges();

        }
        public void RemoveCategory(int id)
        {
            db.Categoryes.Remove(ThisCategory(id));
            db.SaveChanges();
        }

    }
}
