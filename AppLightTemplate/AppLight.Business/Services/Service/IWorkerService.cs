using AppLight.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLight.Business.Services.Service
{
    public interface IWorkerService
    {
        Task CreateAsync(Worker worker);
        Task UpdateAsync(Worker worker);
        Task DeleteAsync(int id);
        Task SoftDelete(int id);
        Task<Worker> GetWorkerAsync(int id);
        Task<List<Worker>> GetAllWorkersAsync();
    }
}
