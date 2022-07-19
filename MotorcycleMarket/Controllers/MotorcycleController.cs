using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MotorcycleMarket.DAL.Interfaces;
using MotorcycleMarket.Domain.Entity;
using MotorcycleMarket.Service.Interfaces;

namespace MotorcycleMarket.Controllers
{
    public class MotorcycleController : Controller
    {

        private readonly IMotorcycleService _motorcycleService;

        public MotorcycleController(IMotorcycleService motorcycleService)
        {
            _motorcycleService = motorcycleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMotorcycle()
        {
            var response = await _motorcycleService.GetAllMotorcycleAsync();
            return View(response);
        }
 
    }
}
