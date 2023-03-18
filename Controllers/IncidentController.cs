using GBCSporting_Team_Amigos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting_Team_Amigos.Controllers
{
    public class IncidentController : Controller
    {
        private Assignment1Context context { get; set; }

        public IncidentController(Assignment1Context ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            ViewBag.Customers = context.Customers;
            ViewBag.Products = context.Products;
            return View(context.Incidents.ToList());
        }

        public IActionResult Add()
        {
            Incident incident = new Incident();
            ViewBag.Action = "Add";
            ViewBag.Customers = context.Customers.ToList();
            ViewBag.Products = context.Products.ToList();
            ViewBag.Technicians = context.Technicians.ToList();
            return View("Edit",incident);
        }

        [HttpPost]
        public IActionResult Add(Incident incident)
        {
            if (ModelState.IsValid)
            {
                context.Incidents.Add(incident);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Action = "Add";
            ViewBag.Customers = context.Customers.ToList();
            ViewBag.Products = context.Products.ToList();
            ViewBag.Technicians = context.Technicians.ToList();
            return View("Edit", incident);
        }


        public IActionResult Edit(int id)
        {
            var incident = context.Incidents.Find(id);
            ViewBag.Customers = context.Customers.ToList();
            ViewBag.Products = context.Products.ToList();
            ViewBag.Technicians = context.Technicians.ToList();
            ViewBag.Action = "Edit";
            return View(incident);
        }

        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            if (ModelState.IsValid)
            {
                context.Incidents.Update(incident);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customers = context.Customers.ToList();
            ViewBag.Products = context.Products.ToList();
            ViewBag.Technicians = context.Technicians.ToList();
            ViewBag.Action = "Edit";
            return View(incident);
        }

        public IActionResult Delete(int id)
        {
            var incident = context.Incidents.Include(t => t.Customer).Include(t => t.Product).Include(t => t.Technician).SingleOrDefault(t => t.IncidentId == id);
            return View(incident);
        }

        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Incidents()
        {
            ViewBag.Customers = context.Customers;
            ViewBag.Products = context.Products;
            return View(context.Incidents.Where(t=>t.TechnicianId != null).ToList());
        }

        public IActionResult Update(int id)
        {
            var incident = context.Incidents.Find(id);
            ViewBag.Customers = context.Customers.ToList();
            ViewBag.Products = context.Products.ToList();
            ViewBag.Technicians = context.Technicians.ToList();
            return View(incident);
        }

        [HttpPost]
        public IActionResult Update(Incident incident)
        {
            if (ModelState.IsValid)
            {
                context.Incidents.Update(incident);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customers = context.Customers.ToList();
            ViewBag.Products = context.Products.ToList();
            ViewBag.Technicians = context.Technicians.ToList();
            return View(incident);
        }



    }
}
