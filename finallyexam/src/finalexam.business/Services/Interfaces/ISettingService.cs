using finalexam.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace finalexam.business.Services.Interfaces
{
    public interface ISettingService
    {
        Task UpdateAsync(Setting setting);
        Task<Setting> GetByIdAsync(int id);
        Task<List<Setting>> GetAllAsync();



    }
}
