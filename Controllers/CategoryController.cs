using la_mia_pizzeria_static.data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using static la_mia_pizzeria_static.Controllers.Repository.DbCenter;

namespace la_mia_pizzeria_static.Controllers
{
    public class CategoryController : Controller
    {
        DbPostRepository db;
        public CategoryController() : base()
        {
            db = new DbPostRepository();
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

            Category Newcategory = db.ThisCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            Newcategory.Name = category.Name;


            db.Save();

            return RedirectToAction("Index");
        }


        //delete
        //si occupa di eliminare una categoria
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Category category = db.ThisCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            db.RemoveCategory(category);
            db.Save();


            return RedirectToAction("Index");
        }
    }
}
