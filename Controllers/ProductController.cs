using GBCSporting_Team_Amigos.Models;
using Microsoft.AspNetCore.Mvc;

namespace GBCSporting_Team_Amigos.Controllers
{
    public class ProductController : Controller
    {
        private Assignment1Context context { get; set; }

        public ProductController(Assignment1Context ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View(context.Products.ToList());
        }

        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            Product product = new Product();
            return View("Edit",product);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Action = "Add";
            return View("Edit", product);
        }

        public IActionResult Edit(int id)
        {
            Product product = context.Products.Find(id);
            ViewBag.Action = "Edit";
            return View("Edit", product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Update(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Action = "Edit";
                return View("Edit", product);
            }
        }

        public IActionResult Delete(int id)
        {
            Product product = context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
