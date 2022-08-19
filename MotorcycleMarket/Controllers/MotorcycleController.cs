using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorcycleMarket.Domain.ViewModels;
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
            var response = _motorcycleService.GetAllMotorcycles();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(response.Data);

            return RedirectToAction("Eror");
        }

        [HttpGet]
        public async Task<IActionResult> GetMotorcycle(int id)
        {
            var response = await _motorcycleService.GetMotorcycle(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(response.Data);

            return RedirectToAction("Eror");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _motorcycleService.DeleteMotorcycle(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(response.Data);

            return RedirectToAction("Eror");
        }

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0) return View();

            var response = await _motorcycleService.GetMotorcycle(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(response.Data);

            return RedirectToAction("Eror");
        }

        [HttpPost]
        public async Task<IActionResult> Save(MotorcycleViewModel model)
        {
            

            return RedirectToAction("GetCars");
        }
    }
}
