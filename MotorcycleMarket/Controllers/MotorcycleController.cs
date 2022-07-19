using Microsoft.AspNetCore.Mvc;
using MotorcycleMarket.DAL.Interfaces;
using MotorcycleMarket.Domain.Entity;

namespace MotorcycleMarket.Controllers
{
    public class MotorcycleController : Controller
    {

        private readonly IMotorcycleRepository _motorcycleRepository;

        public MotorcycleController(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;   
        }

        [HttpGet]
        public async Task<IActionResult> GetMotorcycle()
        {
            var respns = await _motorcycleRepository.Select();
            return View(respns);
        }
 
    }
}
