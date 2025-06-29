using Microsoft.AspNetCore.Mvc;
using QuizMania1.UI.Models;
using System.Diagnostics;

namespace QuizMania1.UI.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Dashboard() 
        {
           // ViewData["UserID"] = HttpContext.Session.GetString("UserID");
            //ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            return View();
        }
    }
}