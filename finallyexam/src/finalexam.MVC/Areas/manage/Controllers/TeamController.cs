using finalexam.business.Exceptions;
using finalexam.business.Services.Interfaces;
using finalexam.core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace finalexam.MVC.Areas.manage.Controllers
{
    [Authorize(Roles ="SuperAdmin")]
    [Area("manage")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamservice;

        public TeamController(ITeamService teamservice)
        {
           _teamservice = teamservice;
        }
        public async Task<IActionResult> Index()
        {
            var teams=await _teamservice.GetAllAsync();
            return View(teams);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Team team)
        {
            if (!ModelState.IsValid)
            {
                return View(team);
            }
            try
            {
                await _teamservice.CreateAsync(team);

            }
            catch(TeamNotFoundException ex)
            {

                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(team);
            }
            catch(ImageContentException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(team);
            }
            catch(InvalidImageSizeExceptiion ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(team);
            }
            catch(Exception ex)
            {
                throw;
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var existteam=await _teamservice.GetByIdAsync(id);  
            if (existteam == null)
            {
                return View("Error");
            }

            return View(existteam);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Team team)
        {
            if(!ModelState.IsValid)
            {
                return View(team);
            }
            try
            {
                await _teamservice.UpdateAsync(team);
            }
            catch(TeamNotFoundException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(team);
            }
            catch(InvalidImageSizeExceptiion ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(team);
            }
            catch(ImageContentException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(team);
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var existteam = await _teamservice.GetByIdAsync(id);
            if (existteam == null)
            {
                return View("Error");
            }

            return View(existteam);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Delete(Team team)
        {
           
            try
            {
                await _teamservice.Delete(team.Id);
            }
            catch (TeamNotFoundException ex) 
            {
                return View("Error");
            }
            catch(Exception ex)
            {
                throw ;
            }
            return RedirectToAction("index");
        }
    }
}
