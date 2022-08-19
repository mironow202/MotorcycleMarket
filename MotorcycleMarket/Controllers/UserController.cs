﻿using Microsoft.AspNetCore.Mvc;
using MotorcycleMarket.Service.Interfaces;

namespace MotorcycleMarket.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> GetUsers()
        {
            var response = await _userService.GetUsers();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}