using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using PruebaMongo.Models;
using PruebaMongo.Repository;
using Newtonsoft.Json;


namespace PruebaMongo.Controllers;

public class PropiedadController : Controller
{
    readonly IPropiedadCollection db;

    public PropiedadController(IPropiedadCollection db)
    {
        this.db = db;
    }


    public IActionResult Listar()
    {
        //var productos = _dbContext.Productos.ToList();
        List<Propiedades> propiedades = db.GetAllPropiedades();

        return View(propiedades);
    }

    [HttpGet]
    public IActionResult Agregar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Agregar(Propiedades propiedades)
    {

        List<string> amenidadesList = propiedades.Amenidades.ToList();

      
        propiedades.Amenidades = amenidadesList;


        db.InsertPropiedad(propiedades);
            return Redirect("/Propiedad/Listar");
    }
       
    

    



}
