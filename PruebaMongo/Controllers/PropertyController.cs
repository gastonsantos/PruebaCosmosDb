using Microsoft.AspNetCore.Mvc;
using PruebaMongo.Models;
using PruebaMongo.Services;

namespace PruebaMongo.Controllers;

public class PropertyController : Controller
{
    readonly IPropertyService _propertyService;

    public PropertyController(IPropertyService propertyService)
    {
        this._propertyService = propertyService;
    }


    public IActionResult Listar()
    {
        return View(this._propertyService.GetAll());
    }

    [HttpGet]
    public IActionResult Agregar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Agregar(Property property)
    {

        List<string> amenidadesList = property.Amenidades.ToList();


        property.Amenidades = amenidadesList;


        _propertyService.Save(property);
        return Redirect("/Property/Listar");

    }
}
