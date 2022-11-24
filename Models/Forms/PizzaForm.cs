using Microsoft.AspNetCore.Mvc.Rendering;

namespace la_mia_pizzeria_static.Models.Forms
{
    public class PizzaForm
    {
        public Pizza Pizza { get; set; }
        public List<Category>? categories { get; set; }

        public List<SelectListItem>? ingredients { get; set; }
        public List<int>? selectIngredient { get; set; }

    }
}
