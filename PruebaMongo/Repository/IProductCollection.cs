using Microsoft.EntityFrameworkCore;
using PruebaMongo.Models;

namespace PruebaMongo.Repository;

public interface IProductCollection 
{
    public List<Products> GetAllProducts();
    public Products GetProductByID(string id);
    public void InsertProduct(Products product);
    public void UpdateProduct(Products product);
    public void DeleteProduct(string id);

     
    

}
