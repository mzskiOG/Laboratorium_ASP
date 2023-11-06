using Laboratorium2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Laboratorium2.Controllers
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

        public IActionResult Error()
        {
            // Tworzymy obiekt ErrorViewModel i przekazujemy go do widoku
            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ShowRequestId = !string.IsNullOrEmpty(Activity.Current?.Id)
            };

            return View(errorViewModel);
        }


        public IActionResult Form()
        {
            return View();
        }

    }
}