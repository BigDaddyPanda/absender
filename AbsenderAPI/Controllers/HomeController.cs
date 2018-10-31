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
        

        public IActionResult Error()
        {

            string[] myArray = { "value01", "value02", "value03" };
            ViewData["admins"] = myArray;
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
