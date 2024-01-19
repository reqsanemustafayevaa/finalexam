using finalexam.business.Exceptions;
using finalexam.business.Services.Implementations;
using finalexam.business.Services.Interfaces;
using finalexam.core.Models;
using Microsoft.AspNetCore.Mvc;

namespace finalexam.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingservice;

        public SettingController(ISettingService settingservice)
        {
            _settingservice = settingservice;
        }
        public async Task<IActionResult> Index()
        {
            var existsetting=await _settingservice.GetAllAsync();
            return View(existsetting);
        }
        public async Task<IActionResult> Update(int id)
        {
            var exissetting = await _settingservice.GetByIdAsync(id);
            if (exissetting == null)
            {
                return View("Error");
            }

            return View(exissetting);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Setting  setting)
        {
            if (!ModelState.IsValid)
            {
                return View(setting);
            }
            try
            {
                await _settingservice.UpdateAsync(setting);
            }
            catch (TeamNotFoundException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(setting);
            }
          
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction("index");
        }
    }
}
