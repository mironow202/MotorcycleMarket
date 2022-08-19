using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MotorcycleMarket.Domain.Entity;
using MotorcycleMarket.Domain.Response;
using MotorcycleMarket.Domain.ViewModels;
using MotorcycleMarket.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MotorcycleMarket.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.LoginAsync(userModel);
                if (response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response.Data));

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", response.Description);
            }
            return View(userModel);
        }


        [HttpGet]       
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.RegisterAsync(userModel);
                if (response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response.Data));


                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", response.Description);
            }
            return View(userModel);
        }


        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }


   
    }
}
