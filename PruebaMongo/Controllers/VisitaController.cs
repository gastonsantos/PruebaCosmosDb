using Microsoft.AspNetCore.Mvc;
using PruebaMongo.Models;
using PruebaMongo.Services.Messages;
using PruebaMongo.Services.Visita;

namespace PruebaMongo.Controllers
{
    public class VisitaController : Controller
    {
        readonly IVisitaService _visitaService;

        public VisitaController(IVisitaService visitaService)
        {
            this._visitaService = visitaService;

        }

        [HttpPost]
        public IActionResult AgendarVisita(Visit visita)
        {

            _visitaService.SendVisita(visita);

            TempData["Mensaje"] = "¡Visita agendada con éxito!";

            return Redirect("/Property/Listar");

        }

    }
}
