using AppLight.Business.Services.Service;
using AppLight.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppLigth.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkerService _workerService;

        public HomeController(IWorkerService workerService)
        {
            _workerService = workerService;
        }
        public async Task<IActionResult> Index()
        {
            List<Worker> workers = await _workerService.GetAllWorkersAsync();

            return View(workers);
        }
    }
}