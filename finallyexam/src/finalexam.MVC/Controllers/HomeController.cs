
using finalexam.data.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace finalexam.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
           var teams=_context.Teams.ToList();
            return View(teams);
        }

       
    }
}
