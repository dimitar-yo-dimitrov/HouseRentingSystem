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

    public async Task<IActionResult> Become(BecomeAgentFormModel agent)
    {
        if (await _agents.ExistsById(User.Id()))
        {
            TempData[ErrorMessage] = InfoMessage;

            return RedirectToAction("Index", "Home");
        }

        return View();
    }
}