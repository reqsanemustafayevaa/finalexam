using finalexam.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalexam.business.Services.Interfaces
{
    public interface ITeamService
    {
        Task CreateAsync(Team team);
        Task UpdateAsync(Team team);
        Task Delete(int Id);
        Task<Team> GetByIdAsync(int Id);
        Task<List<Team>> GetAllAsync();

    }
}
