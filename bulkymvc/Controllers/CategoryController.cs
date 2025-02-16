using bulkymvc.Data;
using bulkymvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace bulkymvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name & Display name cannot be identical.");
            }
            if (ModelState.IsValid)
            {

            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index","Category");
            }
            return View();
        }
    }
}
