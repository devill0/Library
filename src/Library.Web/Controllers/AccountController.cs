using Library.Core.Service;
using Library.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        
        [HttpGet("login")]
        public IActionResult Login()
        {
            var viewModel = new LoginViewModel();

            return View(viewModel);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            userService.Login(viewModel.Email, viewModel.Password);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, viewModel.Email)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principle = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);

            return RedirectToAction("Index", "Books");
        }
    }
}