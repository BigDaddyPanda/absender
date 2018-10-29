using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AbsenderAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace AbsenderAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string[] myArray = { "value01", "value02", "value03" };
            ViewData["Admins"] = myArray;
            return View();

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        [Authorize]
        public IActionResult AdminsList()
        {

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
