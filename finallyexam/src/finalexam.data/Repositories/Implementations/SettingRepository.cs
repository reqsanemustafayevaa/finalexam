using finalexam.core.Models;
using finalexam.core.Repositpories.Interfaces;
using finalexam.data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalexam.data.Repositories.Implementations
{
    public class SettingRepository : GenericRepository<Setting>, ISettingRepository
    {
        public SettingRepository(AppDbContext context) : base(context)
        {
        }
    }
}
