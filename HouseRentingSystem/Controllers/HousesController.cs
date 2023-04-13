using HouseRentingSystem.Core.Models.Houses;
using HouseRentingSystem.Core.Services.Contracts;
using HouseRentingSystem.Extensions;
using HouseRentingSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HouseRentingSystem.Common.GlobalConstants.ExceptionMessages;
using static HouseRentingSystem.Common.GlobalConstants.ValidationConstants;

namespace HouseRentingSystem.Controllers;

public class HousesController : BaseController
{
    private readonly IHouseService _houseService;
    private readonly IAgentService _agentService;
    private readonly ILogger _logger;

    public HousesController(
        IHouseService houseService,
        IAgentService agentService,
        ILogger<HousesController> logger)
    {
        _houseService = houseService;
        _agentService = agentService;
        _logger = logger;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> All([FromQuery] AllHousesQueryModel query)
    {
        var result = await _houseService.AllAsync(
            query.Category,
            query.SearchTerm,
            query.Sorting,
            query.CurrentPage,
            AllHousesQueryModel.HousesPerPage);

        query.TotalHousesCount = result.TotalHousesCount;
        query.Houses = result.Houses;

        var houseCategories = await _houseService.AllCategoryNamesAsync();
        query.Categories = houseCategories;

        return View(query);
    }

    [HttpGet]
    public async Task<IActionResult> Mine()
    {
        return View(new AllHousesQueryModel());
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        try
        {
            if (await _agentService.ExistsByIdAsync(User.Id()) == false)
            {
                _logger.LogWarning(MyLogEvents.GetId, "ExistsById() return false in {0}", DateTime.Now);

                return RedirectToAction(nameof(AgentsController.Become), "Agents");
            }

            var model = new HouseInputModel
            {
                HouseCategories = await _houseService.AllCategoriesAsync()
            };

            return View(model);
        }
        catch (Exception ex)
        {
            _logger.LogError(MyLogEvents.GetItemNotFound, "Something went wrong: {ex}", nameof(Add));

            return NotFound(ex.Message);
        }

    }

    [HttpPost]
    public async Task<IActionResult> Add(HouseInputModel model)
    {
        try
        {
            var userId = User.Id();

            if (!await _agentService.ExistsByIdAsync(userId))
            {
                _logger.LogWarning(MyLogEvents.GetId, "ExistsById() return false in {0}", DateTime.Now);

                return RedirectToAction(nameof(AgentsController.Become), "Agents");
            }

            if (!await _houseService.CategoryExistsAsync(model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), MessageAboutNonExistingCategory);
            }

            if (!ModelState.IsValid)
            {
                model.HouseCategories = await _houseService.AllCategoriesAsync();

                return View(model);
            }

            var agentId = await _agentService.GetAgentIdAsync(userId);

            var houseId = await _houseService.CreateAsync(model, agentId);

            return RedirectToAction(nameof(Details), new { id = houseId });
        }
        catch (Exception ex)
        {
            _logger.LogError(MyLogEvents.GetItemNotFound, "Something went wrong: {ex}", nameof(Add));

            return NotFound(ex.Message);
        }
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