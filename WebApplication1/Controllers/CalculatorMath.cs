using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index(double? a, double? b, string operation = "add")
        {
            if (a == null || b == null)
            {
                ViewBag.Result = null;
                return View();
            }

            double result = 0;
            string message = "";

            switch (operation.ToLower())
            {
                case "add":
                case "+":
                    result = a.Value + b.Value;
                    message = $"{a} + {b} = {result}";
                    break;
                case "sub":
                case "-":
                    result = a.Value - b.Value;
                    message = $"{a} - {b} = {result}";
                    break;
                case "mul":
                case "*":
                    result = a.Value * b.Value;
                    message = $"{a} * {b} = {result}";
                    break;
                case "div":
                case "/":
                    if (b.Value != 0)
                    {
                        result = a.Value / b.Value;
                        message = $"{a} / {b} = {result}";
                    }
                    else
                    {
                        message = "Nie można dzielić przez zero";
                    }
                    break;
                default:
                    message = "Nieznana operacja.";
                    break;
            }
            
            ViewBag.Result = result;
            ViewBag.Message = message;
            
            return View();
        }
    }
}