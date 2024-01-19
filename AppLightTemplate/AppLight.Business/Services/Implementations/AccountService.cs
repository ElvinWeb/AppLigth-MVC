using AppLight.Business.CustomExceptions.User;
using AppLight.Business.Services.Service;
using AppLight.Business.ViewModels;
using AppLight.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLight.Business.Services.Implementations
{
    internal class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task Login(AdminLoginViewModel adminLoginViewModel)
        {
            User admin = null;

            admin = await _userManager.FindByNameAsync(adminLoginViewModel.Username);

            if (admin == null) throw new InvalidCredentials("", "username or password is wrong!");

            var result = await _signInManager.PasswordSignInAsync(admin, adminLoginViewModel.Password, false, false);

            if (!result.Succeeded) throw new InvalidCredentials("", "username or password is wrong!");
        }

        public async Task Logout()
        {
           await _signInManager.SignOutAsync();
        }
    }
}
