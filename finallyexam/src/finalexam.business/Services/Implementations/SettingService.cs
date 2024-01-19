using finalexam.business.Exceptions;
using finalexam.business.Services.Interfaces;
using finalexam.core.Models;
using finalexam.core.Repositpories.Interfaces;
using finalexam.data.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace finalexam.business.Services.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingService(ISettingRepository settingRepository)
        {
           _settingRepository = settingRepository;
        }

        public async Task<List<Setting>> GetAllAsync()
        {
            return await _settingRepository.GetAllAsync().ToListAsync();
        }

        public Task<Setting> GetByIdAsync(int id)
        {
            var existsetting = _settingRepository.GetByIdAsync(x => x.Id == id);
            if (existsetting == null)
            {
                throw new SettingNotFoundException("","setting not found");
            }
            return existsetting;
        }

        public async Task UpdateAsync(Setting setting)
        {
            var existsetting =await _settingRepository.GetByIdAsync(x => x.Id == setting.Id);
            if (existsetting == null)
            {
                throw new SettingNotFoundException("", "setting not found");
            }
            existsetting.Value = setting.Value;
            existsetting.UpdatedDate= DateTime.UtcNow;
            await _settingRepository.CommitAsync();
        }
    }
}
