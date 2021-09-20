using KleineDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KleineDemo.Controllers
{
    public class HeroesController : Controller
    {
        private MijnContext _context;

        public HeroesController(MijnContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //helden ophalen
            var heroes = _context.Heroes.ToList();

            return View(heroes);
        }

        public IActionResult Show()
        {
            return View();
        }
    }
}
