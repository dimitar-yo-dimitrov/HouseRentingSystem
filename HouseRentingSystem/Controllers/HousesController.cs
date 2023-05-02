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
        try
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
        catch (Exception ex)
        {
            _logger.LogError(MyLogEvents.GetItemNotFound, "Something went wrong: {ex}", nameof(All));

            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Mine()
    {
        try
        {
            var userId = User.Id();

            IEnumerable<HouseServiceModel> myHouses;

            if (await _agentService.ExistsByIdAsync(userId))
            {
                var currentAgentId = await _agentService.GetAgentIdAsync(userId);

                myHouses = await _houseService.AllHousesByAgentIdAsync(currentAgentId);
            }
            else
            {
                myHouses = await _houseService.AllHousesByUserIdAsync(userId);
            }

            return View(myHouses);
        }
        catch (Exception ex)
        {
            _logger.LogError(MyLogEvents.GetItemNotFound, "Something went wrong: {ex}", nameof(Mine));

            return NotFound(ex.Message);
        }
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
    public async Task<IActionResult> Details(int id)
    {
        try
        {
            if (await _houseService.ExistsAsync(id) == false)
            {
                _logger.LogWarning(MyLogEvents.GetId, "ExistsById() return false in {0}", DateTime.Now);

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var houseModel = await _houseService.HouseDetailsByIdAsync(id);

            return View(houseModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(MyLogEvents.GetItemNotFound, "Something went wrong: {ex}", nameof(Details));

            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        try
        {
            if (await _houseService.ExistsAsync(id) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if (await _houseService.HasAgentWithId(id, User.Id()) == false)
            {
                _logger.LogInformation("User with id {0} attempted to open other agent house", User.Id());

                return RedirectToPage("Account/AccessDenied", new { area = "Identity" });
            }

            var house = await _houseService.HouseDetailsByIdAsync(id);
            var houseCategoryId = await _houseService.GetHouseCategoryId(id);

            var model = new HouseInputModel
            {
                Id = id,
                Address = house.Address,
                Description = house.Description,
                CategoryId = houseCategoryId,
                Title = house.Title,
                PricePerMonth = house.PricePerMonth,
                ImageUrl = house.ImageUrl,
                HouseCategories = await _houseService.AllCategoriesAsync()
            };

            return View(model);
        }
        catch (Exception ex)
        {
            _logger.LogError(MyLogEvents.GetItemNotFound, "Something went wrong: {ex}", nameof(Edit));

            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, HouseInputModel house)
    {
        try
        {
            if (house == null)
            {
                throw new ArgumentException(string.Format(IdIsNull));
            }

            if (id != house.Id)
            {
                return RedirectToPage("Account/AccessDenied", new { area = "Identity" });
            }

            if (await _houseService.HasAgentWithId(id, User.Id()) == false)
            {
                _logger.LogInformation("User with id {0} attempted to open other agent house", User.Id());

                return RedirectToPage("Account/AccessDenied", new { area = "Identity" });
            }

            if (await _houseService.ExistsAsync(id) == false)
            {
                ModelState.AddModelError("", "The house does not exist!");

                house.HouseCategories = await _houseService.AllCategoriesAsync();

                return View(house);
            }

            if (!ModelState.IsValid)
            {
                return View(house);
            }

            await _houseService.EditAsync(id, house);

            return RedirectToAction(nameof(Details), new { id });
        }
        catch (Exception ex)
        {
            _logger.LogError(MyLogEvents.GetItemNotFound, "Something went wrong: {ex}", nameof(Edit));

            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        return View(new HouseDetailsServiceModel());
    }

    [HttpPost]
    public async Task<IActionResult> Delete(HouseDetailsServiceModel house)
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