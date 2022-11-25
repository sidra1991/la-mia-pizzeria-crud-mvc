using la_mia_pizzeria_static.data;
using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Forms;

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
        public void AddPizza(PizzaForm forms, List<Ingredient> ingredients)
        {
            Pizza newPizza = forms.Pizza;
            newPizza.Category = ThisCategory(forms.Pizza.CategoryId);
            newPizza.Ingredients = new();
            foreach (var item in forms.Ingredients)
            {
                newPizza.Ingredients.Add(item);
            }
            newPizza.CategoryId = forms.Pizza.CategoryId;
            Pizzas.Add(newPizza);
        }
        public void RemovePizza(Pizza pizza)
        {
            Pizzas.Remove(pizza);
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
            Pizzas.Remove(forms.Pizza);
            Pizzas.Add(uploadPizza);
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
        public void RemoveIngredient(int id)
        {
            Ingredients.Remove(ThisIngredient(id));
        }
        public void UpdateIngredient(int id, Ingredient ingredient)
        {
            ThisIngredient(id).Name = ingredient.Name;
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
        public void RemoveCategory(int id)
        {
            Categories.Remove(ThisCategory(id));
        }
        public void UpdateCategory(int id, Category category)
        {
            ThisCategory(category.Id).Name = category.Name;
        }
    }
}
