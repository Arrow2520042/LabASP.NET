using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _service;
        
        public ReservationController(IReservationService service)
        {
            _service = service;
        }
        
        public IActionResult Index()
        {
            var list = _service.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Reservation model)
        {
            if (ModelState.IsValid)
            {
                _service.Add(model);
                return RedirectToAction("Index"); 
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = _service.FindById(id);
            if (model == null) return NotFound();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Reservation model)
        {
            if (ModelState.IsValid)
            {
                _service.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var model = _service.FindById(id);
            if (model == null) return NotFound();
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var model = _service.FindById(id);
            if (model == null) return NotFound();
            return View(model);
        }
        
        [HttpPost] 
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}