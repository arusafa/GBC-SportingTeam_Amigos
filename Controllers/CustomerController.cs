using GBCSporting_Team_Amigos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting_Team_Amigos.Controllers
{
    public class CustomerController : Controller
    {
        
        private Assignment1Context context { get; set; }

        public CustomerController(Assignment1Context ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View(context.Customers.ToList());
        }

        public IActionResult Add()
        {
            Customer customer = new Customer();
            ViewBag.Action = "Add";
            ViewBag.Countries = context.Countries.ToList();
            return View("Edit",customer);
        }

        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            if (ModelState.IsValid)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Action = "Add";
            ViewBag.Countries = context.Countries.ToList();
            return View("Edit", customer);
        }

        public IActionResult Edit(int id)
        {
            Customer customer = context.Customers.Find(id);
            ViewBag.Action = "Edit";
            ViewBag.Countries = context.Countries.ToList();
            return View("Edit",customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                context.Customers.Update(customer);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Countries = context.Countries.ToList();
            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            Customer customer = context.Customers.Find(id);
            Country country = context.Countries.Find(customer.CountryId);
            ViewBag.Country = country.CountryName;
            return View(customer);
        }


        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
