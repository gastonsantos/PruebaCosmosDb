using PruebaMongo.Models;

namespace PruebaMongo.Repository;

public interface IProductCollection
{
    public List<Product> GetAllProducts();
    public Product GetProductByID(string id);
    public void InsertProduct(Product product);
    public void UpdateProduct(Product product);
    public void DeleteProduct(string id);
}
