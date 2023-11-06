using Laboratorium2._2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium2._2.Controllers
{
    public class CalculatorController : Controller
    {
        public enum Operator
        {
            Add, Mul, Sub, Div
        }

        [HttpPost]
        public IActionResult Result([FromForm] Calculator model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }
            return View(model);
        }

        public IActionResult Form()
        {
            return View();
        }
    }
}
