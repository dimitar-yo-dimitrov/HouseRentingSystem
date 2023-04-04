using HouseRentingSystem.Core.Services.Contracts;
using HouseRentingSystem.Core.ViewModels.Agents;
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
    public async Task<IActionResult> Become(BecomeAgentInputModel model)
    {
        var userId = User.Id();

        if (await _agents.ExistsById(userId))
        {
            TempData[ErrorMessage] = InfoMessageForExistingAgent;

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        if (await _agents.UserWithPhoneNumberExists(model.PhoneNumber))
        {
            ModelState.AddModelError(nameof(model.PhoneNumber), InfoMessageForExistingPhoneNumber);
        }

        if (await _agents.UserHasRents(userId))
        {
            ModelState.AddModelError("Error", InfoMessageForAlreadyExistingRent);
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _agents.Create(userId, model.PhoneNumber);

        return RedirectToAction(nameof(HousesController.All), "Houses");
    }
}