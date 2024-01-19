using finalexam.business.Exceptions;
using finalexam.business.Services.Interfaces;
using finalexam.business.ViewModels;
using finalexam.core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalexam.business.Services.Implementations
{
    
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthService(UserManager<AppUser>userManager,SignInManager<AppUser>signInManager)
        {
           _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task Login(LoginViewModel loginVm)
        {
            AppUser admin = null;
            admin=await _userManager.FindByNameAsync(loginVm.UserName);
            if (admin == null)
            {
                throw new InvalidAuthException("","UserName or password incorrect!");
            }
            var result= await _signInManager.PasswordSignInAsync(admin, loginVm.Password,false,false);
            if (!result.Succeeded)
            {
                throw new InvalidAuthException("", "UserName or password incorrect!");
            }
           
        }
    }
}
