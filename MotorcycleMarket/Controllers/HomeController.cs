﻿using Microsoft.AspNetCore.Mvc;
using MotorcycleMarket.DAL.Interfaces;
using MotorcycleMarket.Models;
using System.Diagnostics;

namespace MotorcycleMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
      
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() => View();
    }
}