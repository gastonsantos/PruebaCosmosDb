using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using PruebaMongo.Models;
using PruebaMongo.Repository;

namespace PruebaMongo.Controllers;

public class ProductController : Controller
{
    readonly IProductCollection db;
    
    
    public ProductController(IProductCollection db)
    {
        this.db = db;
       
       
    }
  
    public IActionResult Listar()
    {
        //var productos = _dbContext.Productos.ToList();
        List<Products> product = db.GetAllProducts();

        return View(product);
    }
    
    [HttpGet]
    public IActionResult Agregar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Agregar(Products product)
    {
      
        db.InsertProduct(product);
        return Redirect("/Product/Listar");

    }
    public IActionResult Detalle(string id)
    {
        Products product = db.GetProductByID(id);
        return View(product);
    }

    public IActionResult Modificar(string id)
    {
        Products product = db.GetProductByID(id);


        return View(product);
    }

    [HttpPost]
    public IActionResult Modificar(IFormCollection formulario)
    {
        Products productoModificado = new Products();
        //string ids = formulario["Id"];
        var ids = ObjectId.Parse(formulario["Id"]);
        productoModificado.Id = ids;
        productoModificado.Name = formulario["Nombre"];
        productoModificado.Stock = int.Parse(formulario["Stock"]);
        productoModificado.Category = formulario["Categoria"];
        
  

        db.UpdateProduct(productoModificado);
        return Redirect("/Product/Listar");
    }
    public IActionResult Eliminar(string id)
    {
        db.DeleteProduct(id);
        return Redirect("/Product/Listar");
    }

}
