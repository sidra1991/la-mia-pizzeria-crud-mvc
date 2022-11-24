using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace la_mia_pizzeria_static.data
{
    public class PizzaDB : DbContext
    {
        public DbSet<Pizza>Pizze { get; set; }
        public DbSet<Category>Categoryes { get; set; }

        public DbSet<Ingredient> Ingredientes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=ultimissimo;Integrated Security=True;Encrypt=false;");
        }
    }
}
