using la_mia_pizzeria_static.data;
using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;
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
        public void AddPizza(Pizza pizza)
        {
            db.Pizze.Add(pizza);
        }
        public void RemovePizza(Pizza pizza)
        {
            db.Pizze.Remove(pizza);
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
        }
        public void RemoveIngredient(Ingredient ingredient)
        {
            db.Ingredientes.Remove(ingredient);
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
        }
        public void RemoveCategory(Category category)
        {
            db.Categoryes.Remove(category);
        }
        public void Save()
        {
            db.SaveChanges();
        }

    }
}
