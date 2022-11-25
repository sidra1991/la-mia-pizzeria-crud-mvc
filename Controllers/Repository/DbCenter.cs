using la_mia_pizzeria_static.data;
using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;
using static la_mia_pizzeria_static.Controllers.Repository.DbCenter;

namespace la_mia_pizzeria_static.Controllers.Repository
{
    public class DbCenter
    {

        public class DbPostRepository
        {
            private PizzaDB db;

            public DbPostRepository()
            {
                db = new PizzaDB();
            }


            public Pizza TihisPizza(int id)
            {
                return db.Pizze.Where(Pizza => Pizza.Id == id).Include("Category").Include("Ingredients").FirstOrDefault();
            }
            public Ingredient ingredient(int id)
            {
                return db.Ingredientes.Where(i => i.Id == id).FirstOrDefault();
            }
            public List<Pizza> ListPizze()
            {
                return db.Pizze.ToList();
            }
            public List<Ingredient> ListIngredient()
            {
                return db.Ingredientes.ToList();
            }
            public List<Category> ListCategory()
            {
                return db.Categoryes.ToList();
            }
            public void AddPizza(Pizza pizza)
            {
                db.Pizze.Add(pizza);
            }
            public void RemovePizza(Pizza pizza)
            {
                db.Pizze.Remove(pizza);
            }
            public void Save()
            {
                db.SaveChanges();
            }

        }

    }
}
