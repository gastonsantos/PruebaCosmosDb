using Microsoft.AspNetCore.Mvc;
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
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Listar()
    {
        //var productos = _dbContext.Productos.ToList();
        List<Product> product = db.GetAllProducts();

        return View(product);
    }
    [HttpGet]
    public IActionResult Agregar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Agregar(Product product)
    {
        //_dbContext.Productos.Add(product);
        //_dbContext.SaveChanges();

        db.InsertProduct(product);
        return Redirect("/Product/Listar");

    }
    public IActionResult Detalle(string id)
    {
        Product product = db.GetProductByID(id);
        return View(product);
    }

    public IActionResult Modificar(string id)
    {
        Product product = db.GetProductByID(id);


        return View(product);
    }

    [HttpPost]
    public IActionResult Modificar(IFormCollection formulario)
    {
        Product productoModificado = new Product();
        //string ids = formulario["Id"];
        var ids = ObjectId.Parse(formulario["Id"]);
        productoModificado.Id = ids;
        productoModificado.Name = formulario["Nombre"];
        productoModificado.Stock = int.Parse(formulario["Stock"]);
        productoModificado.Category = formulario["Categoria"];
        
        /*
        List<Product> ListProd = new List<Product>();

        Product producto1 = new Product();
        producto1.Id = new ObjectId(ids);
        producto1.Name = "Manteca";
        producto1.Stock = 2;
        producto1.Category = "Heladera";

        Product producto2 = new Product();
        producto2.Id = new ObjectId(ids);
        producto2.Name = "Banana";
        producto2.Stock = 2;
        producto2.Category = "Verduleria";

        ListProd.Add(producto1);
        ListProd.Add(producto2);
*/
    

        db.UpdateProduct(productoModificado);
        return Redirect("/Product/Listar");
    }
    public IActionResult Eliminar(string id)
    {
        db.DeleteProduct(id);
        return Redirect("/Product/Listar");
    }

}
