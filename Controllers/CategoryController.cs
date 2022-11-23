using la_mia_pizzeria_static.data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class CategoryController : Controller
    {
        PizzaDB db;
        public CategoryController() : base()
        {
            db = new PizzaDB();
        }
        public IActionResult Index()
        {
            if (db.categoryes.ToList().Count > 0)
            {
                List<Category> categoryes = db.categoryes.ToList();
                return View("Index", categoryes);
            }
            else
            {
                List<Category> categoryes = new List<Category>();
                return View("Index", categoryes);
            }
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Category NewCategory = category;

            db.categoryes.Add(NewCategory);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //public IActionResult Update(int id)
        //{
        //    Category category = db.categoryes.Where(categor => categor.Id == id).FirstOrDefault();

        //    if (category == null)
        //        return NotFound();


        //    return ActionResult("Update", category);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Category category)
        {

            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            Category Newcategory = db.categoryes.Where(post => post.Id == id).FirstOrDefault();

            if (category == null)
            {
                return NotFound();
            }

            Newcategory.Name = category.Name;


            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Category category = db.categoryes.Where(cat => cat.Id == id).FirstOrDefault();

            if (category == null)
            {
                return NotFound();
            }

            db.categoryes.Remove(category);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}
