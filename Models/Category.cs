using la_mia_pizzeria_static.Validations;
using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Category
    {
        
        public int Id { get; set; }
        [Required (ErrorMessage ="campo obbligatorio")]
        //[ExistValidationsCustom]
        public string Name { get; set; }
        
        List<Pizza> Pizzas { get; set; }

        public Category()
        {
        }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}
