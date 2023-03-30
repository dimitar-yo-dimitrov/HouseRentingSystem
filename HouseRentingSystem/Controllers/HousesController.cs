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
    public async Task<IActionResult> Add(HouseFormModel house)
    {
        return RedirectToAction(nameof(Details), new { id = "1" });
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        return View(new HouseDetailsViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Edit(string id, HouseFormModel house)
    {
        return RedirectToAction(nameof(Details), new { id = "1" });
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        return View(new HouseDetailsViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Delete(HouseDetailsViewModel house)
    {
        return RedirectToAction(nameof(All));
    }

    [HttpPost]
    public async Task<IActionResult> Rent(string id)
    {
        return RedirectToAction(nameof(Mine));
    }

    [HttpPost]
    public async Task<IActionResult> Leave(string id)
    {
        return RedirectToAction(nameof(Mine));
    }
}