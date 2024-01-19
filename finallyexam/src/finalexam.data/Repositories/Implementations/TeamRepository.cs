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
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(AppDbContext context) : base(context)
        {
        }
    }
}
