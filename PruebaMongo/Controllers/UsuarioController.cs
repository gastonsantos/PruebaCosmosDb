using Microsoft.AspNetCore.Mvc;
using PruebaMongo.Models;
using PruebaMongo.Repository;
using System.Data;

namespace PruebaMongo.Controllers;

public class UsuarioController : Controller
{
    readonly IUsuarioCollection db;

    public UsuarioController(IUsuarioCollection db)
    {
        this.db = db;

    }
    public IActionResult RegistrarUsuario()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RegistrarUsuario(Usuario usuario)
    {
        db.InsertUsuario(usuario);
        return Redirect("");
    }

}
