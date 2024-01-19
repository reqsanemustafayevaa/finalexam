using finalexam.business.Services.Interfaces;
using finalexam.core.Models;

namespace finalexam.MVC.ViewServices
{
    public class LayoutService
    {
        private readonly ISettingService _settingService;

        public LayoutService(ISettingService settingService)
        {
            _settingService = settingService;
        }
        public async Task<List<Setting>> Getsetting()
        {
          return  await _settingService.GetAllAsync();
        }

    }
}
