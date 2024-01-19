using AppLight.Business.CustomExceptions.General;
using AppLight.Business.Services.Service;
using AppLight.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace AppLigth.UI.areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin")]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public async Task<IActionResult> Index()
        {
            List<Setting> settingList = await _settingService.GetAllSettingsAsync();

            return View(settingList);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Setting setting = null;

            try
            {
                setting = await _settingService.GetSettingAsync(id);
            }
            catch (InvalidIdOrBelowThanZero ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(setting);
            }
            catch (Exception ex)
            {
                return View(setting);
            }

            if (setting == null) return View();

            return View(setting);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Setting setting)
        {
            try
            {
                await _settingService.UpdateAsync(setting);
            }
            catch (InvalidEntityException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(setting);

            }
            catch (Exception ex)
            {
                return View(setting);
            }

            return RedirectToAction("index", "setting");
        }

    }
}
