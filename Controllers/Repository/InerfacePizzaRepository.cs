using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Controllers.Repository
{
    public interface InerfacePizzaRepository
    {
        void AddCategory(Category category);
        void AddIngredient(Ingredient ingredient);
        void AddPizza(Pizza pizza);
        List<Category> ListCategory();
        List<Ingredient> ListIngredient();
        List<Pizza> ListPizze();
        void RemoveCategory(Category category);
        void RemoveIngredient(Ingredient ingredient);
        void RemovePizza(Pizza pizza);
        void Save();
        Category ThisCategory(int id);
        Ingredient ThisIngredient(int id);
        Pizza TihisPizza(int id);
    }
}