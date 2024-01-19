
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace finalexam.MVC.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

       
    }
}
