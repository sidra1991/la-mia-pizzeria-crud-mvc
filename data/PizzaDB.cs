using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace la_mia_pizzeria_static.data
{
    public class PizzaDB : DbContext
    {
        public DbSet<Pizza>pizze { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=pizza;Integrated Security=True;Encrypt=false;");
        }
    }
}
