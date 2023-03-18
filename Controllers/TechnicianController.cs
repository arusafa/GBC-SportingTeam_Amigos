using GBCSporting_Team_Amigos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting_Team_Amigos.Controllers
{
    public class TechnicianController : Controller
    {
        private Assignment1Context context { get; set; }

        public TechnicianController(Assignment1Context ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View(context.Technicians.ToList());
        }

        public IActionResult Add()
        {
            Technician technician = new Technician();
            ViewBag.Action = "Add";
            return View("Edit", technician);
        }

        [HttpPost]
        public IActionResult Add(Technician technician)
        {
            if (ModelState.IsValid)
            {
                context.Technicians.Add(technician);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Action = "Add";
                return View("Edit", technician);
            }
        }

        public IActionResult Edit(int id)
        {
            Technician technician = context.Technicians.Find(id);
            ViewBag.Action = "Edit";
            return View(technician);
        }

        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            if (ModelState.IsValid)
            {
                context.Technicians.Update(technician);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(technician);
        }

        public IActionResult Delete(int id)
        {
            Technician technician = context.Technicians.Find(id);
            return View(technician);
        }

        [HttpPost]
        public IActionResult Delete(Technician technician)
        {
            context.Technicians.Remove(technician);
            context.SaveChanges();
            return RedirectToAction("Index");            
        }
    }
}
