using HouseRentingSystem.Core.ViewModels.Agents;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers;

public class AgentsController : BaseController
{
    public IActionResult Become(BecomeAgentFormModel agent)
    {
        return RedirectToAction(nameof(HousesController.All), "Houses");
    }
}