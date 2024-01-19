using AppLight.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLight.Business.Services.Service
{
    public interface ISettingService
    {
        Task UpdateAsync(Setting setting);
        Task<Setting> GetSettingAsync(int id);
        Task<List<Setting>> GetAllSettingsAsync();
    }
}
