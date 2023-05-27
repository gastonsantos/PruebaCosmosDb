using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Recommendations;
using MongoDB.Bson;
using PruebaMongo.Models;
using PruebaMongo.Repository;
using PruebaMongo.Services;
using PruebaMongo.Services.Agents;
using PruebaMongo.Services.Users;
using Microsoft.Extensions.Configuration;



namespace PruebaMongo.Controllers;

public class PropertyController : Controller
{
    readonly IPropertyService _propertyService;
    readonly IAgentService _agentService;
    readonly IUserService _userService;

    public PropertyController(IPropertyService propertyService, IAgentService agentService, IUserService userService)
    {
        this._propertyService = propertyService;
        this._agentService = agentService;
    }

    public IActionResult Listar()
    {
        var states = this._propertyService.getAllState();
        var location = this._propertyService.getAllLocation();

        ViewBag.states = new SelectList(states,states);
        ViewBag.location = new SelectList(location, location);

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


    public IActionResult GetRecommendedProperties()
    {
        User user = this._userService.GetUserById("647112daa470860fb213457c");
        IList<Property> recommendedPropertiesForUser = this._propertyService.RecommendProperties(user);

        return View(recommendedPropertiesForUser);
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

    [HttpGet]
    public ActionResult BuscarPropiedades(string state, string location, string operation)
    {
        // Aquí puedes realizar la lógica de búsqueda de propiedades según los parámetros recibidos

        // Ejemplo de redirección a una acción de resultados de búsqueda
        return RedirectToAction("Resultados", List);
    }
    [HttpGet]
    public ActionResult Resultados(string state, string location, string idb)
    {
        // Aquí puedes realizar la lógica para obtener los resultados de búsqueda basados en los parámetros recibidos

        // Ejemplo de pasaje de los parámetros a la vista de resultados
        ViewBag.State = state;
        ViewBag.Location = location;
        ViewBag.Idb = idb;

        return View();
    }


}
