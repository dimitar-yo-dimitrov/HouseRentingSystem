using System.Diagnostics;
using HouseRentingSystem.Core.Services.Contracts;
using HouseRentingSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHouseService _houseService;

        public HomeController(
            ILogger<HomeController> logger,
            IHouseService houseService)
        {
            _logger = logger;
            _houseService = houseService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var houses = await _houseService.LastThreeHouses();

            return View(houses);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}