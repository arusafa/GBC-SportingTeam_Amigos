using GBCSporting_Team_Amigos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GBCSporting_Team_Amigos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("About")]
        public IActionResult About()
        {
            ViewData["Message"] = "About Page";
            return View();
        }
    }
}