using BookStoreWeb.Data;
using BookStoreWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _dbc;

        public CategoryController(ApplicationDBContext dbc)
        {
            _dbc = dbc;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _dbc.Categories.ToList();
            return View(categoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _dbc.Categories.Add(obj);
                _dbc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //Get
        public IActionResult Edit(int id)
        {
            if (id is 0)
                return NotFound();
            //Category categorySingle = _dbc.Categories.SingleOrDefault(c => c.Id == id);
            //Category categoryFirst = _dbc.Categories.FirstOrDefault(c => c.Id == id);
            Category category = _dbc.Categories.Find(id);
            if (category == null)
                return NotFound();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _dbc.Categories.Update(obj);
                _dbc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IActionResult Delete(int id)
        {
            if (id is 0)
                return NotFound();
            //Category categorySingle = _dbc.Categories.SingleOrDefault(c => c.Id == id);
            //Category categoryFirst = _dbc.Categories.FirstOrDefault(c => c.Id == id);
            Category category = _dbc.Categories.Find(id);
            if (category == null)
                return NotFound();
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            Category category = _dbc.Categories.Find(id);
            if (category is null)
                return NotFound();

            _dbc.Categories.Remove(category);
            _dbc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
