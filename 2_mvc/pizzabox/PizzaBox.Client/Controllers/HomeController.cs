using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
    [Route("/[Controller]/[Action]")]    //Route parameters. Only listening for the first, second parts after the domain name in the uri.
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // [Route("/[controller]/[action]")]       //this one has it's own route now
        [HttpGet("{id}")]             //Filter parameters. filters after the action.
        public IActionResult Index(string id)
        {
            ViewBag.name = id;
            ViewData["Name"] = id;
            TempData["Name"] = id; 

            return View(new Pizza());
        }

        [HttpPost()]
        public IActionResult Order(Pizza p)
        { 
            if (ModelState.IsValid)
            {
                ViewBag.Pizza = p;
                return View("Index", new Pizza());
            }
            return View("Index", p);
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
