using AppLight.Business.CustomExceptions.User;
using AppLight.Business.Services.Service;
using AppLight.Business.ViewModels;
using AppLight.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppLigth.UI.areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
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
        public async Task<IActionResult> Login(AdminLoginViewModel adminLoginViewModel)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                await _accountService.Login(adminLoginViewModel);
            }
            catch (InvalidCredentials ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(adminLoginViewModel);
            }
            catch (Exception ex)
            {
                return View(adminLoginViewModel);
            }

            return RedirectToAction("index", "worker");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();

            return RedirectToAction("login", "account");
        }

        //public async Task<IActionResult> CreateAdmin()
        //{
        //    User admin = new User()
        //    {
        //        UserName = "Admin1",
        //        FullName = "Elvin Sarkarov"
        //    };

        //    var result = await _userManager.CreateAsync(admin, "#Admin1234");


        //    return Ok(result);
        //}


        //public async Task<IActionResult> CreateRole()
        //{
        //    IdentityRole role1 = new IdentityRole("Admin");
        //    IdentityRole role2 = new IdentityRole("SuperAdmin");
        //    IdentityRole role3 = new IdentityRole("Member");

        //    await _roleManager.CreateAsync(role1);
        //    await _roleManager.CreateAsync(role2);
        //    await _roleManager.CreateAsync(role3);

        //    return Ok("roles elave edildi!");
        //}

        //public async Task<IActionResult> AddRole()
        //{
        //    var admin = await _userManager.FindByNameAsync("Admin1");

        //    await _userManager.AddToRoleAsync(admin, "SuperAdmin");


        //    return Ok("role admine elave edildi");
        //}

    }
}
