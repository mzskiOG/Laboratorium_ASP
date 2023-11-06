using Microsoft.AspNetCore.Mvc;

public enum Operators
{
    Add, Mul, Sub, Div
}

public class CalculatorController : Controller
{
    public IActionResult Result(double? a, double? b, Operators? op)
    {


        if (a.HasValue && b.HasValue && op.HasValue)
        {
            double result = 0;
            string operatorSymbol = "";

            switch (op.Value)
            {
                case Operators.Add:
                    result = a.Value + b.Value;
                    operatorSymbol = "add";
                    break;
                case Operators.Mul:
                    result = a.Value * b.Value;
                    operatorSymbol = "mul";
                    break;
                case Operators.Sub:
                    result = a.Value - b.Value;
                    operatorSymbol = "sub";
                    break;
                case Operators.Div:
                    if (b.Value != 0)
                    {
                        result = a.Value / b.Value;
                        operatorSymbol = "div";
                    }
                    else
                    {
                        ViewBag.Error = "Division by zero is not allowed.";
                        return View("Error");
                    }
                    break;
                default:
                    ViewBag.Error = "Invalid operator.";
                    return View("Error");
            }

            ViewBag.Result = $"Result of {a} {operatorSymbol} {b} = {result}";
            return View();
        }
        else
        {
            ViewBag.Error = "Invalid parameters.";
            return View("Error");
        }
    }
}
