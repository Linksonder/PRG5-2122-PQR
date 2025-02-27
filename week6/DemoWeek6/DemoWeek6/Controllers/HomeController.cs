﻿using DemoWeek6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWeek6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View(new PingWing());
        }

        [HttpPost]
        public IActionResult Index(PingWing pingwing)       
        {
            if(!ModelState.IsValid)
            {
                //Toevoegen aan DB
               
                return View(pingwing);
            }
            else
            {
                pingwing.Id = pingwing.Naam;
                _context.PingWings.Add(pingwing);
                _context.SaveChanges();
                return View("PingWingDetails", pingwing);
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
