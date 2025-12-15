using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BirthController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Welcome(Birth model)
        {
            if (!model.IsValid())
            {
                ViewBag.ErrorMessage = "Podane dane są nieprawidłowe ";
                return View("Index", model);
            }
            return View("result",model);
        }
    }
}