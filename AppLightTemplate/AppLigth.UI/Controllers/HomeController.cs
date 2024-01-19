using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppLigth.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
    }
}