using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetAllMotorcycles()
        {
            var response = await _motorcycleService.GetAllMotorcycleAsync();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Eror");
        }

        [HttpGet]
        public async Task<IActionResult> GetMotorcycle(int id)
        {
            var response = await _motorcycleService.GetMotorcycleAsync(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(response.Data);

            return RedirectToAction("Eror");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _motorcycleService.DeleteMotorcycleAsync(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(response.Data);

            return RedirectToAction("Eror");
        }

        public async Task<IActionResult> Save(int id)
        {
            if (id == 0) return View();

            var response = await _motorcycleService.GetMotorcycleAsync(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }

            return RedirectToAction("Eror");
        }
    }
}
