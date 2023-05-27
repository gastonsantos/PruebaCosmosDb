using Microsoft.AspNetCore.Mvc;
using PruebaMongo.Models;
using PruebaMongo.Services;
using PruebaMongo.Services.Agents;
using PruebaMongo.Services.Messages;
using PruebaMongo.Services.Users;

namespace PruebaMongo.Controllers
{
    public class ContactoController : Controller
        
    {
        readonly IMessageService _messageService;

        public ContactoController(IMessageService messageService)
        {
            this._messageService = messageService;
            
        }

        [HttpPost]
        public IActionResult MensajeNuevo(string Nombre, string Email, string Mensaje)
        {

            Contacto message = new Contacto();
            message.Nombre = Nombre;
            message.Email = Email;
            message.Mensaje = Mensaje;

            this._messageService.SendMessage(message);

           
           
            return Redirect("/Property/Listar");
        }
    }
}
