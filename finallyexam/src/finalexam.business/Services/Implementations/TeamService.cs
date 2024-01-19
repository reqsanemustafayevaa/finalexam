using finalexam.business.Exceptions;
using finalexam.business.Extentions;
using finalexam.business.Services.Interfaces;
using finalexam.core.Models;
using finalexam.core.Repositpories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalexam.business.Services.Implementations
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IWebHostEnvironment _env;

        public TeamService(ITeamRepository teamRepository
                           ,IWebHostEnvironment env)
        {
           _teamRepository = teamRepository;
           _env = env;
        }
        public async Task CreateAsync(Team team)
        {
            if (team == null)
            {
                throw new TeamNotFoundException();
            }
            if(team.ImageFile != null)
            {
                if(team.ImageFile.ContentType!="image/jpeg" && team.ImageFile.ContentType != "image/png")
                {
                    throw new ImageContentException("ImageFile","fie must be .png or jpeg!");
                }
                if (team.ImageFile.Length > 2077432)
                {
                    throw new InvalidImageSizeExceptiion("ImageFile", "file must be lower than 2mb!");
                }
                team.ImageUrl = team.ImageFile.SaveFille(_env.WebRootPath, "uploads/teams");
            }
            team.IsDeleted=false;
            team.CrteatedDate= DateTime.UtcNow;
            team.UpdatedDate= DateTime.UtcNow;
            await _teamRepository.CreateAsync(team);
            await _teamRepository.CommitAsync();
        }

        public async Task Delete(int Id)
        {
            var existteam =await _teamRepository.GetByIdAsync(x => x.Id == Id);
            if (existteam == null)
            {
                throw new TeamNotFoundException();
            }
            _teamRepository.Delete(existteam);
            await _teamRepository.CommitAsync();
        }

        public async Task<List<Team>> GetAllAsync()
        {
           return await _teamRepository.GetAllAsync().ToListAsync();
        }

        public Task<Team> GetByIdAsync(int Id)
        {
           var existteam=_teamRepository.GetByIdAsync(x=> x.Id == Id);
            if (existteam == null)
            {
                throw new TeamNotFoundException();
            }
            return existteam;
        }

        public async Task UpdateAsync(Team team)
        {
            if (team == null)
            {
                throw new TeamNotFoundException();
            }
            var existteam=await _teamRepository.GetByIdAsync(x=>x.Id == team.Id);
            if(existteam == null)
            {
                throw new TeamNotFoundException();
            }
            if (team.ImageFile != null)
            {
                if (team.ImageFile.ContentType != "image/jpeg" && team.ImageFile.ContentType != "image/png")
                {
                    throw new ImageContentException("ImageFile", "fie must be .png or jpeg!");
                }
                if (team.ImageFile.Length > 2077432)
                {
                    throw new InvalidImageSizeExceptiion("ImageFile", "file must be lower than 2mb!");
                }
                Helper.DeleteFile(_env.WebRootPath, "uploads/teams", existteam.ImageUrl);
                existteam.ImageUrl = team.ImageFile.SaveFille(_env.WebRootPath, "uploads/teams");

            }
            existteam.FullName = team.FullName;
            
            existteam.Profession=team.Profession;
            existteam.UpdatedDate = DateTime.UtcNow;
            existteam.IsDeleted = false;
            await _teamRepository.CommitAsync();


        }
    }
}
