using AppLight.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppLigth.UI.areas.manage.Controllers
{
    [Area("manage")]
    public class WorkerController : Controller
    {
        public WorkerController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Worker worker)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Update(Worker worker)
        {
            return View();
        }
        [HttpGet]
        public IActionResult SoftDelete(int id)
        {
            return View();
        }
    }
}
