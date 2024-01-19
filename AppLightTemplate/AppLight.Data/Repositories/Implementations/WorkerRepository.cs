using AppLight.Core.Entities;
using AppLight.Core.Repositories;
using AppLight.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLight.Data.Repositories.Implementations
{
    public class WorkerRepository : GenericRepository<Worker>, IWorkerRepository
    {
        public WorkerRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
