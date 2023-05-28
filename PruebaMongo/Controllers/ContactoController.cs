using Microsoft.AspNetCore.Mvc;
using PruebaMongo.Models;
using PruebaMongo.Services;
using PruebaMongo.Services.Agents;
using PruebaMongo.Services.Messages;
using PruebaMongo.Services.Users;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Security.Principal;
using System.Text;

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
            if (!IsReCaptchValid())
            {
                // ModelState.AddModelError("", "Validación Captcha incorrecta");
                //return Redirect("/Property/Listar");
                TempData["ErrorCaptcha"] = "Validación Captcha incorrecta";
                return Redirect("/Property/Listar");
            }
            else
            {
                TempData["CorrectCaptcha"] = "Gracias Por Contactarte con nosotros";
                Contacto message = new Contacto();
                message.Nombre = Nombre;
                message.Email = Email;
                message.Mensaje = Mensaje;

                this._messageService.SendMessage(message);

                return Redirect("/Property/Listar");

            }
            
        }




        public bool IsReCaptchValid()
        {
            var result = false;
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = "6LdIHkMmAAAAAAmZZqHJn22-6Qvh3OI_y1ak5f_o"; // Reemplaza con tu clave secreta de reCaptcha
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify";

            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            var postData = $"secret={secretKey}&response={captchaResponse}";
            var postDataBytes = Encoding.UTF8.GetBytes(postData);

            request.ContentLength = postDataBytes.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(postDataBytes, 0, postDataBytes.Length);
            }

            using (var response = request.GetResponse())
            {
                using (var stream = new StreamReader(response.GetResponseStream()))
                {
                    var jsonResponse = stream.ReadToEnd();

                    JObject jResponse = JObject.Parse(jsonResponse);
                    var isSuccess = jResponse.Value<bool>("success");
                    result = isSuccess;
                }
            }

            return result;
        }

       
    }
}
