using AutoMapper;
using Library.Core.Service;
using Library.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }
        
        [HttpGet("login")]
        public IActionResult Login()
        {          
            return View();
        }

        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm]LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            try
            {
                userService.Login(viewModel.Email, viewModel.Password);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                return View(viewModel);
            }
            var user = userService.Get(viewModel.Email);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Id.ToString())
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principle = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);

            return RedirectToAction("Index", "Books");
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            var viewModel = new RegisterViewModel();

            return View(viewModel);
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            try
            {
                userService.Register(viewModel.Email, viewModel.Password, viewModel.Role);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                return View(viewModel);
            }

            return RedirectToAction(nameof(Login));
        }
    }
}