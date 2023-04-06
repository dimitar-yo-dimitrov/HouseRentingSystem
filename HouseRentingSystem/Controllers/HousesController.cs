using HouseRentingSystem.Core.Models.Houses;
using HouseRentingSystem.Core.Services.Contracts;
using HouseRentingSystem.Extensions;
using HouseRentingSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers;

public class HousesController : BaseController
{
    private readonly IHouseService _houseService;
    private readonly IAgentService _agentService;

    public HousesController(
        IHouseService houseService,
        IAgentService agentService)
    {
        _houseService = houseService;
        _agentService = agentService;
    }

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

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var userId = User.Id();

        if (!await _agentService.ExistsByIdAsync(userId))
        {
            RedirectToAction(nameof(AgentsController.Become), "Agents");
        }

        var model = new HouseInputModel
        {
            HouseCategories = await _houseService.AllCategoriesAsync()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(HouseInputModel model)
    {
        var userId = User.Id();

        if (!await _agentService.ExistsByIdAsync(userId))
        {
            RedirectToAction(nameof(AgentsController.Become), "Agents");
        }

        if (!await _houseService.CategoryExistsAsync(model.CategoryId))
        {
            ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists");
        }

        if (ModelState.IsValid)
        {
            model.HouseCategories = await _houseService.AllCategoriesAsync();

            return View(model);
        }

        var agentId = await _agentService.GetAgentIdAsync(userId);

        var houseId = await _houseService.CreateAsync(model, agentId);

        return RedirectToAction(nameof(Details), new { id = houseId });
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Details(string id)
    {
        return View(new HouseDetailsViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Edit(string id, HouseInputModel house)
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