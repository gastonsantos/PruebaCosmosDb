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
    public IActionResult Agregar(Property propiedades)
    {

        List<string> amenidadesList = propiedades.Amenidades.ToList();

      
        propiedades.Amenidades = amenidadesList;


       this._propertyService.InsertProperty(propiedades);
       return Redirect("/Property/Listar");
    }
}
