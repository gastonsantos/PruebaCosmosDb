using MongoDB.Bson;
using MongoDB.Driver;
using PruebaMongo.Models;

namespace PruebaMongo.Repository;

public class ProductRepository : IProductCollection
{
    public AppContext context;

    public ProductRepository ()
    {
        context = new(ConnectionFactory.GetConnection());
    }


    public void DeleteProduct(string id)
    {
        var producto = context.Products.FirstOrDefault(Product => Product.Id == new ObjectId(id));

        context.Products.Remove(producto);
        context.SaveChanges();
    }

    public List<Products> GetAllProducts()
    {
        return context.Products.AsQueryable().ToList(); // expresion en LINQ
    }

    public Products GetProductByID(string id)
    {
        var producto = context.Products.FirstOrDefault(Product => Product.Id == new ObjectId(id));
        context.SaveChanges();

        return producto;
    }

    public void InsertProduct(Products product)
    {
        context.Products.Add(product);
        context.SaveChanges();
    }

    public void UpdateProduct(Products product)
    {
        var ExistProducto = context.Products.FirstOrDefault(p => p.Id == product.Id);
        if (product != null)
        {
            ExistProducto.Name = product.Name;
            ExistProducto.Stock = product.Stock;
            ExistProducto.Category = product.Category;
            context.SaveChanges();
        }
    }
}
