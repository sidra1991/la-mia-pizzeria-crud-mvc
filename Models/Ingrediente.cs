﻿namespace la_mia_pizzeria_static.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pizza> Pizzas { get; set; }

    }
}
