using Laboratorium_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Laboratorium_1.Controllers
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


        public IActionResult About(Operator op)
        {
            ViewBag.Op = op;
            return View();
        }
         public enum Operator
        {
            Unknown, Add, Mul, Sub, Div
        }
        public IActionResult Calculator(Operator op, double? a, double? b)
        {
            if (!a.HasValue || !b.HasValue)
            {
                ViewBag.Error = "Invalid input. Please enter valid numbers.";
                return View();
            }

            double result = 0;

            switch (op)
            {
                case Operator.Add:
                    result = a.Value + b.Value;
                    break;
                case Operator.Mul:
                    result = a.Value * b.Value;
                    break;
                case Operator.Sub:
                    result = a.Value - b.Value;
                    break;
                case Operator.Div:
                    if (b.Value != 0)
                    {
                        result = a.Value / b.Value;
                    }
                    else
                    {
                        ViewBag.Error = "Division by zero is not allowed.";
                        return View();
                    }
                    break;
                default:
                    ViewBag.Error = "Invalid operator. Please select a valid operator.";
                    return View();
            }

            ViewBag.Expression = $"{a} {op} {b}";
            ViewBag.Result = $"Wynik działania dla {ViewBag.Expression} = {result}";
            return View();
        }

    }
}