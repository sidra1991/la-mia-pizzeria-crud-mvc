using la_mia_pizzeria_static.data;
using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Validations
{
    public class ExistValidationsCustom : ValidationAttribute
    {

        //protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        //{
        //    PizzaDB db = new PizzaDB();

        //    Category? category = db.Categoryes.Where(cat => cat.Name == value).FirstOrDefault();

        //    if ( category != null )
        //    {
        //        return new ValidationResult(" questa categoria esiste gia ");
        //    }

        //    return base.IsValid(value, validationContext: validationContext);
        //}

    }
}
