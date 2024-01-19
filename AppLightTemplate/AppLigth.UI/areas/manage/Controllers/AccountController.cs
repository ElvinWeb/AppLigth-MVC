using AppLight.Business.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppLigth.UI.areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AdminLoginViewModel adminLoginViewModel)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
