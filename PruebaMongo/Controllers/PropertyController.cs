using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;
using PruebaMongo.Models;
using PruebaMongo.Repository;
using PruebaMongo.Services;
using PruebaMongo.Services.Agents;



namespace PruebaMongo.Controllers;

public class PropertyController : Controller
{
    readonly IPropertyService _propertyService;
    readonly IAgentService _agentService;

    public PropertyController(IPropertyService propertyService, IAgentService agentService)
    {
        this._propertyService = propertyService;
        this._agentService = agentService;
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
      
        
        var agents = this._agentService.GetAllAgents();
        ViewBag.Agents = new SelectList(agents, "Id", "Nombre");
       // ViewBag.Agents = new SelectList(agents);
        return View();
    }

    [HttpPost]
    public IActionResult Agregar(Property property, IFormFile imagen, string agent, string provincia, string localidad, string calle, int numero, string codigoPostal, string departamento, string piso )
    {
        //codigo Imagen
        Property propiedades1 = property;
        if (imagen != null)
        {
            string path = Path.Combine("wwwroot/", property.Titulo + ".jpg");

            var stream = new FileStream(path, FileMode.Create);

            imagen.CopyTo(stream);

            

            propiedades1.Imagen = @"\" + property.Titulo + ".jpg";

        }
        else
        {
            propiedades1.Imagen = "/Assets/default-house-image.jpg";
        }
       
        //codigo Amenidades
        List<string> amenidadesList = property.Amenidades.ToList();

        property.Amenidades = amenidadesList;


        property.Agente= this._agentService.GetAgente(agent);

        Ubicacion ubicacion= new Ubicacion();
        
        ubicacion.Provincia = provincia;
        ubicacion.Localidad = localidad;
        ubicacion.Calle = calle;
        ubicacion.CodigoPostal = codigoPostal;
        ubicacion.Numero = numero;
        ubicacion.Departamento = departamento;
        ubicacion.Piso = piso;

        property.Ubicacion= ubicacion;
     


        _propertyService.Save(property);
        return Redirect("/Property/Listar");


    }
}
