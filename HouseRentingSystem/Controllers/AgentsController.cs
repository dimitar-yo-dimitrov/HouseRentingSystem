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

    public async Task<IActionResult> Become(BecomeAgentInputModel agent)
    {
        if (!await _agents.ExistsById(User.Id()))
        {
            return View(agent);
        }

        TempData[ErrorMessage] = InfoMessage;

        return RedirectToAction("Index", "Home");
    }
}