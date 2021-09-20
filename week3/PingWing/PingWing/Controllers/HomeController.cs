using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PingWing.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PingWing.Controllers
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

        //Rename van privacy naar pingwing
        public IActionResult PingWings()
        {
            //Hier ga ik naar de DB
            List<Dier> dieren = new List<Dier>();
            dieren.Add(new Dier() { Age = 3, Name = "Ping Wing Master", Type = "Pinguin" });
            dieren.Add(new Dier() { Age = 2, Name = "Ping Wing Support", Type = "Pinguin" });
            dieren.Add(new Dier() { Age = 5, Name = "Ping Wing Midlane", Type = "Pinguin" });

            return View(dieren);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
