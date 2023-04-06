using HouseRentingSystem.Core.Models.Agents;
using HouseRentingSystem.Core.Services.Contracts;
using HouseRentingSystem.Extensions;
using Microsoft.AspNetCore.Mvc;
using static HouseRentingSystem.Common.GlobalConstants.ExceptionMessages;

namespace HouseRentingSystem.Controllers;

public class AgentsController : BaseController
{
    private readonly IAgentService _agents;

    public AgentsController(IAgentService agents)
    {
        _agents = agents;
    }

    [HttpGet]
    public async Task<IActionResult> Become()
    {
        if (await _agents.ExistsByIdAsync(User.Id()))
        {
            TempData[ErrorMessage] = InfoMessageForExistingAgent;

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        var model = new BecomeAgentInputModel();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Become(BecomeAgentInputModel model)
    {
        var userId = User.Id();

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (await _agents.UserWithPhoneNumberExistsAsync(model.PhoneNumber))
        {
            ModelState.AddModelError(nameof(model.PhoneNumber), InfoMessageForExistingPhoneNumber);
        }

        if (await _agents.UserHasRentsAsync(userId))
        {
            ModelState.AddModelError("Error", InfoMessageForAlreadyExistingRent);
        }

        await _agents.CreateAsync(userId, model.PhoneNumber);

        return RedirectToAction(nameof(HousesController.All), "Houses");
    }
}