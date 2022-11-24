using la_mia_pizzeria_static.data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace la_mia_pizzeria_static.Models
{


    public class Pizza
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Url(ErrorMessage = "questo deve essere un url valido")]
        public string ImageAddress { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(100, ErrorMessage = "la descrizione è troppo lunga")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Range(1, 10, ErrorMessage = "il prezzo non è valido")]
        public int Price { get; set; }
        //[Required(ErrorMessage = "Il campo è obbligatorio")]   <---- bastardaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa

        public List<Ingredient>? Ingredients { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public Pizza()
        {

        }
        public Pizza(string name, string imageAddress, string description, int price, int CategoryId)
        {
            this.CategoryId = CategoryId;
            Name = name;
            ImageAddress = imageAddress;
            Description = description;
            Price = price;
        }

    }
}
