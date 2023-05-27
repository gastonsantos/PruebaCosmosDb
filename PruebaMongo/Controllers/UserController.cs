using Microsoft.AspNetCore.Mvc;
using PruebaMongo.Models;
using PruebaMongo.Services;
using PruebaMongo.Services.Users;

namespace PruebaMongo.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IPropertyService _propertyService;

    public UserController(IUserService userService, IPropertyService propertyService)
    {
        _userService = userService;
        _propertyService = propertyService;
    }


    [HttpPost]
    public IActionResult TogglePropertyFavorite(string propertyId)
    {
        var property = this._propertyService.getPropertyById(propertyId);
        this._userService.TogglePropertyFavorite(property, "647112daa470860fb213457c");

        return RedirectToAction("Detalle", "Property", new { id = property.Id.ToString() });
    }
}
