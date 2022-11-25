using la_mia_pizzeria_static.Controllers.Repository;
using la_mia_pizzeria_static.data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class CategoryController : Controller
    {
        DbPizzaRepository db;
        public CategoryController() : base()
        {
            db = new DbPizzaRepository();
        } 

        //index
        //si occupa ri restituire la listadelle categorie in fase di gestione di queste
        public IActionResult Index()
        {
            if (db.ListCategory().Count > 0)
            {
                return View("Index", db.ListCategory());
            }
            else 
            { 
                return View("Index", new List<Category>());
            }
        }

        //create
        //si occupa di creare una nuova categoria
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Category NewCategory = category;

            db.AddCategory(NewCategory);
            db.Save();

            return RedirectToAction("Index");
        }

        //update
        //si occupa di modificare il nome di una categoria
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Category category)
        {

            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            if (category == null)
            {
                return NotFound();
            }

            db.ThisCategory(id).Name = category.Name;


            db.Save();

            return RedirectToAction("Index");
        }


        //delete
        //si occupa di eliminare una categoria
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (db.ThisCategory(id) == null)
            {
                return NotFound();
            }

            db.RemoveCategory(db.ThisCategory(id));
            db.Save();


            return RedirectToAction("Index");
        }
    }
}
