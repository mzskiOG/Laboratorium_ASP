using Microsoft.AspNetCore.Mvc;
using Laboratorium2._2.Models;

namespace Laboratorium2._2.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Index()
        {
            var model = new Birth();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Birth model)
        {
            model.CalculateAge(); // Wywołaj metodę CalculateAge() na obiekcie model

            return View(model);
        }
    }
}

