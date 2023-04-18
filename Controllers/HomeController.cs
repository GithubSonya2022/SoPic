using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoPic.Models;
using System;
using System.Diagnostics;

namespace SoPic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        //public HomeController()
        //{
        //}

        public IActionResult Index()
        {
            return View();
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

        public  new ViewResult ProblemDetailsFactory(string v)
        {
            throw NotImplementedException();
        }

        private Exception NotImplementedException()
        {
            throw new NotImplementedException();
        }

        internal ViewResult Details(string v)
        {
            throw new NotImplementedException();
        }
    }
}
