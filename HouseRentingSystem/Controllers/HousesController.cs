using HouseRentingSystem.Infrastructure.Data.Models;
using HouseRentingSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers;

public class HousesController : BaseController
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> All([FromQuery] AllHousesQueryModel model)
    {
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Mine()
    {
        return View(new AllHousesQueryModel());
    }

    [HttpPost]
    public async Task<IActionResult> Add()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        return View(new HouseDetailsViewModel());
    }
}