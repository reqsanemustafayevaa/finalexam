using finalexam.business.Exceptions;
using finalexam.business.Services.Interfaces;
using finalexam.business.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace finalexam.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                await _authService.Login(model);
            }
            catch (InvalidAuthException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch(Exception ex)
            {
                throw;
            }
            return RedirectToAction("index", "team");
        }
    }
}
