using AppLight.Core.Repositories;
using AppLight.Data.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppLight.Data
{
    public static class RepositoryRegistration
    {
        public static void RepositoriesRegister(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IWorkerRepository, WorkerRepository>();
            serviceDescriptors.AddScoped<ISettingRepository, SettingRepository>();
        }
    }
}
