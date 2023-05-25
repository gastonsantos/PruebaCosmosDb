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

    public IActionResult Detalle(string id)
    {
        Property property = _propertyService.getPropertyById(id);

        return View(property);
    }

    [HttpGet]
    public IActionResult Agregar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Agregar(Property property, IFormFile imagen)
    {
        string path = Path.Combine("wwwroot/", property.Titulo + ".jpg");
        // string path = Path.Combine("wwwroot/", imagen.FileName);

        var stream = new FileStream(path, FileMode.Create);


        imagen.CopyTo(stream);

        Property propiedades1 = property;

        propiedades1.Imagen = @"\" + property.Titulo + ".jpg";

        List<string> amenidadesList = property.Amenidades.ToList();


        property.Amenidades = amenidadesList;


        _propertyService.Save(property);
        return Redirect("/Property/Listar");


    }
}
