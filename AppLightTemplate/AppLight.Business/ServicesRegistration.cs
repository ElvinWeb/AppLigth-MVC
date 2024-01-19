using AppLight.Business.Services.Implementations;
using AppLight.Business.Services.Service;
using AppLight.Core.Repositories;
using AppLight.Data.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLight.Business
{
    public static class ServicesRegistration
    {
        public static void ServicesRegister(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IWorkerService, WorkerService>();
            serviceDescriptors.AddScoped<ISettingService, SettingService>();
            serviceDescriptors.AddScoped<IAccountService, AccountService>();
        }
    }
}
