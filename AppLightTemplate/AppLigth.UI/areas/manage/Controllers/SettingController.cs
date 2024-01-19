using AppLight.Business.Services.Service;
using AppLight.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppLigth.UI.areas.manage.Controllers
{
    [Area("manage")]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Setting setting)
        {
            return View();
        }

    }
}
