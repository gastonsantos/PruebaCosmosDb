using Microsoft.AspNetCore.Mvc;
using PruebaMongo.Services.Agents;
using PruebaMongo.Services.Users;
using PruebaMongo.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using PruebaMongo.Models;
using MongoDB.Driver;

namespace PruebaMongo.Controllers
{
    public class AdminController : Controller
    {
        readonly IPropertyService _propertyService;
        readonly IAgentService _agentService;
        //readonly IUserService _userService;

        public AdminController(IPropertyService propertyService, IAgentService agentService)
        {
            this._propertyService = propertyService;
            this._agentService = agentService;
        }


        public IActionResult Listar()
        {
            var states = this._propertyService.getAllState();
            var location = this._propertyService.getAllLocation();

            ViewBag.states = new SelectList(states, states);
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
        [HttpPost]
        public IActionResult Agregar(Property property, IFormFile imagen, string agent, string provincia, string localidad, string calle, int numero, string codigoPostal, string departamento, string piso)
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


            property.Agente = this._agentService.GetAgente(agent);

            Ubicacion ubicacion = new Ubicacion();

            ubicacion.Provincia = provincia;
            ubicacion.Localidad = localidad;
            ubicacion.Calle = calle;
            ubicacion.CodigoPostal = codigoPostal;
            ubicacion.Numero = numero;
            ubicacion.Departamento = departamento;
            ubicacion.Piso = piso;

            property.Ubicacion = ubicacion;



            _propertyService.Save(property);
            return Redirect("/Property/Listar");
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
             this._propertyService.DeleteProperty(id);

            return Redirect("/Admin/Listar");
        }

        [HttpGet]
        public IActionResult Modificar(string id)
        {
            var agents = this._agentService.GetAllAgents();
            ViewBag.Agents = new SelectList(agents, "Id", "Nombre");

            var property = this._propertyService.getPropertyById(id);

            return  View(property);
        }

        [HttpPost]
        public IActionResult Modificar(Property property, string Id, string agent, string provincia, string localidad, string calle, int numero, string codigoPostal, string departamento, string piso)
        {
        
            var propertyBd = this._propertyService.getPropertyById(Id);


            propertyBd.Titulo = property.Titulo;
            propertyBd.Descripcion = property.Descripcion;
            propertyBd.Banos = property.Banos;
            propertyBd.Garaje = property.Garaje;
            propertyBd.Habitaciones = property.Habitaciones;
            propertyBd.MetrosCuadrados = property.MetrosCuadrados;
            propertyBd.Precio = property.Precio;
            property.Imagen = property.Imagen;
            propertyBd.Operacion = property.Operacion; 
            List<string> amenidadesList = property.Amenidades.ToList();
            propertyBd.Amenidades = amenidadesList;

            property.Agente = this._agentService.GetAgente(agent);

            Ubicacion ubicacion = new Ubicacion();

            ubicacion.Provincia = provincia;
            ubicacion.Localidad = localidad;
            ubicacion.Calle = calle;
            ubicacion.CodigoPostal = codigoPostal;
            ubicacion.Numero = numero;
            ubicacion.Departamento = departamento;
            ubicacion.Piso = piso;

            propertyBd.Ubicacion = ubicacion;

            this._propertyService.EditProperty(propertyBd);

            return Redirect("/Admin/Listar");

        }


    }
}
