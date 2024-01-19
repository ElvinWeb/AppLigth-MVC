using AppLight.Business.CustomExceptions.General;
using AppLight.Business.Services.Service;
using AppLight.Core.Entities;
using AppLight.Core.Repositories;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLight.Business.Services.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public async Task<List<Setting>> GetAllSettingsAsync()
        {
            return await _settingRepository.GetAllAysnc(x => !x.IsDeleted);
        }

        public async Task<Setting> GetSettingAsync(int id)
        {
            return await _settingRepository.GetByIdAysnc(x => !x.IsDeleted && x.Id == id);
        }

        public async Task UpdateAsync(Setting setting)
        {
            Setting wantedSetting = await _settingRepository.GetByIdAysnc(x => x.Id == setting.Id && !x.IsDeleted);
            if (wantedSetting == null) throw new InvalidEntityException("", "Entity is null here!");

            wantedSetting.Value = setting.Value;
            wantedSetting.UpdatedDate = DateTime.UtcNow.AddHours(4);

            await _settingRepository.SaveAsync();
        }
    }
}
