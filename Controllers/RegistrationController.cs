using GBCSporting_Team_Amigos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting_Team_Amigos.Controllers
{
    public class RegistrationController : Controller
    {
        private Assignment1Context context { get; set; }

        public RegistrationController(Assignment1Context ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View(context.Registrations.Include(t=>t.Product).Include(t=>t.Customer).ToList());
        }

        public IActionResult Add()
        {
            Registration registration = new Registration();
            ViewBag.Action = "Add";
            ViewBag.Customers = context.Customers;
            ViewBag.Products = context.Products;
            return View("Edit", registration);
        }

        [HttpPost]
        public IActionResult Add(Registration registration)
        {
            if (ModelState.IsValid)
            {
                context.Registrations.Add(registration);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Action = "Add";
            ViewBag.Customers = context.Customers;
            ViewBag.Products = context.Products;
            return View("Edit", registration);
        }

        public IActionResult Edit(int id)
        {
            Registration registration = context.Registrations.Find(id);
            ViewBag.Action = "Edit";
            ViewBag.Customers = context.Customers;
            ViewBag.Products = context.Products;
            return View(registration);
        }

        [HttpPost]
        public IActionResult Edit(Registration registration)
        {
            if (ModelState.IsValid)
            {
                context.Registrations.Update(registration);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Action = "Edit";
            ViewBag.Customers = context.Customers;
            ViewBag.Products = context.Products;
            return View("Edit", registration);
        }

        public IActionResult Delete(int id)
        {
            Registration registration = context.Registrations.Include(t => t.Product).Include(t => t.Customer).SingleOrDefault(t=>t.RegistrationId == id);
            return View(registration);
        }

        [HttpPost]
        public IActionResult Delete(Registration rgs)
        {
            context.Registrations.Remove(rgs);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
