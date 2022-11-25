using la_mia_pizzeria_static.data;
using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Controllers.Repository
{
    public class LocalPizzaRepository : InerfacePizzaRepository
    {
        public static List<Pizza> Pizzas = new();
        public static List<Ingredient> Ingredients = new();
        public static List<Category> Categories = new();


        public LocalPizzaRepository()
        {
        }


        //funzioni DB per pizza
        public Pizza TihisPizza(int id)
        {
            return Pizzas.Where(Pizza => Pizza.Id == id).FirstOrDefault();
        }
        public List<Pizza> ListPizze()
        {
            return Pizzas.ToList();
        }
        public void AddPizza(Pizza pizza)
        {
            Pizzas.Add(pizza);
        }
        public void RemovePizza(Pizza pizza)
        {
            Pizzas.Remove(pizza);
        }


        //funzioni DB per ingredienti
        public Ingredient ThisIngredient(int id)
        {
            return Ingredients.Where(i => i.Id == id).FirstOrDefault();
        }
        public List<Ingredient> ListIngredient()
        {
            return Ingredients.ToList();
        }
        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }
        public void RemoveIngredient(Ingredient ingredient)
        {
            Ingredients.Remove(ingredient);
        }

        //funzioni DB per category
        public Category ThisCategory(int id)
        {
            return Categories.Where(post => post.Id == id).FirstOrDefault();
        }
        public List<Category> ListCategory()
        {
            return Categories.ToList();
        }
        public void AddCategory(Category category)
        {
            Categories.Add(category);
        }
        public void RemoveCategory(Category category)
        {
            Categories.Remove(category);
        }
        public void Save()
        {
            //db.SaveChanges();
        }
    }
}
