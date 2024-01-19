using AppLight.Business.Services.Service;
using AppLight.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace AppLigth.UI.ViewService
{
    public class LayoutService
    {
        private readonly ISettingService _settingService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public LayoutService(ISettingService settingService, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _settingService = settingService;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<List<Setting>> GetSettings()
        {
            var settingsList = await _settingService.GetAllSettingsAsync();

            return settingsList;
        }

        public async Task<User> GetAdmin()
        {
            User admin = null;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                admin = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            }

            return admin;
        }
    }
}
