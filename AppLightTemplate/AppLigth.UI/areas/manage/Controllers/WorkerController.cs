using AppLight.Business.CustomExceptions.General;
using AppLight.Business.CustomExceptions.WorkerImage;
using AppLight.Business.Services.Service;
using AppLight.Core.Entities;
using AppLight.Data.Repositories.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppLigth.UI.areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin")]
    public class WorkerController : Controller
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }
        public async Task<IActionResult> Index()
        {
            List<Worker> workers = await _workerService.GetAllWorkersAsync();

            return View(workers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(Worker worker)
        {
            if (!ModelState.IsValid) return View(worker);

            try
            {
                await _workerService.CreateAsync(worker);
            }
            catch (InvalidImageContentTypeOrSize ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(worker);
            }
            catch (ImageRequired ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(worker);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "unexpected error!");
                return View();
            }

            return RedirectToAction("index", "worker");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Worker worker = null;
            try
            {
                worker = await _workerService.GetWorkerAsync(id);
            }
            catch (InvalidIdOrBelowThanZero ex)
            {
                return View("error");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "unexpected error!");
                return View();
            }

            return View(worker);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Update(Worker worker)
        {
            if (!ModelState.IsValid) return View(worker);

            try
            {
                await _workerService.UpdateAsync(worker);
            }
            catch (InvalidImageContentTypeOrSize ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(worker);
            }
            catch (InvalidEntityException ex)
            {
                return View("error");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "unexpected error!");
                return View();
            }

            return RedirectToAction("index", "worker");
        }
        [HttpGet]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                await _workerService.SoftDelete(id);
            }
            catch (InvalidIdOrBelowThanZero ex)
            {
                return View("error");
            }
            catch (InvalidEntityException ex)
            {
                return View("error");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "unexpected error!");
                return View();
            }

            return Ok();
        }

        //[Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _workerService.DeleteAsync(id);
            }
            catch (InvalidIdOrBelowThanZero ex)
            {
                return View("error");
            }
            catch (InvalidEntityException ex)
            {
                return View("error");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "unexpected error!");
                return View();
            }

            return RedirectToAction("index", "worker");
        }
    }
}
