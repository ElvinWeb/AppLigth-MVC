using AppLight.Business.Services.Service;
using AppLight.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLight.Business.Services.Implementations
{
    internal class AccountService : IAccountService
    {
        public AccountService()
        {
            
        }
        public Task Login(AdminLoginViewModel adminLoginViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
