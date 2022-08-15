using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MotorcycleMarket.Domain.Entity;
using MotorcycleMarket.Domain.Response;
using MotorcycleMarket.Domain.ViewModels.Registration;
using MotorcycleMarket.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace MotorcycleMarket.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _accountService.Authenticate(model);

            if (response == null)
            {
                return BadRequest(new {message = "Username or passord is incorr" } );
            }
            return Ok(response);
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






        #region test
        //[Authorize]
        //public IQueryable<User> GetAll()
        //{
        //    return _accountService.GetAll();
        //}

        //[Authorize]
        //[HttpGet]
        //public User GetById(int id)
        //{
        //    return _accountService.GetAll().FirstOrDefault(x => x.Id == id);
        //}
        #endregion
    }
}
