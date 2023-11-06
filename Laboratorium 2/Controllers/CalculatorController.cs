using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_2.Controllers
{
    public class CalculatorController : Controller
    {

        public IActionResult Form()
        {
            return View();
        }
        public enum Operators
        {
            Add,
            Mul,
            Sub,
            Div
        }

            public IActionResult Result(double? a, double? b, Operators op)
            {
                if (!a.HasValue || !b.HasValue)
                {
                    ViewBag.Error = "Invalid input. Please enter valid numbers.";
                    return View("Form");
                }

                double result = 0;

                switch (op)
                {
                    case Operators.Add:
                        result = a.Value + b.Value;
                        break;
                    case Operators.Mul:
                        result = a.Value * b.Value;
                        break;
                    case Operators.Sub:
                        result = a.Value - b.Value;
                        break;
                    case Operators.Div:
                        if (b.Value != 0)
                        {
                            result = a.Value / b.Value;
                        }
                        else
                        {
                            ViewBag.Error = "Division by zero is not allowed.";
                            return View("Form");
                        }
                        break;
                    default:
                        ViewBag.Error = "Invalid operator. Please select a valid operator.";
                        return View();
                }

                ViewBag.Expression = $"{a} {op} {b}";
                ViewBag.Result = $"Wynik działania dla {ViewBag.Expression} = {result}";
                return View("Result");
            }
        }
    }

