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
    public class SettingRepository : GenericRepository<Setting>, ISettingRepository
    {
        public SettingRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
