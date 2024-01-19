using AppLight.Business.Services.Service;
using AppLight.Core.Entities;
using NuGet.Versioning;

namespace AppLigth.UI
{
    public class LayoutService
    {
        private readonly ISettingService _settingService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LayoutService(ISettingService settingService, IHttpContextAccessor httpContextAccessor)
        {
            _settingService = settingService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Setting>> GetSettings()
        {
            var settingsList = await _settingService.GetAllSettingsAsync();

            return settingsList;
        }
    }
}
