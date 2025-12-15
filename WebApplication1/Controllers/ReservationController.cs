using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Reservation model)
        {
            if (ModelState.IsValid)
            {
                return View("Result", model);
            }
            return View("Index", model);
        }
    }
}