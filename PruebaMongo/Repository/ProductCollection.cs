using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoFramework;
using PruebaMongo.Models;
using System.Linq;
using System.Xml;

namespace PruebaMongo.Repository
{
    public class ProductCollection : IProductCollection
    {
        private  static IMongoDbConnection ConectionStringMongo()
        {
            //var connection1 = MongoDbConnection.FromUrl(new MongoUrl("mongodb://tpweb3:zrBcQovBkgZmRlyGKnB9nSBV4iDbnQNVR1QqwsaHdjDBygm7Kie8F8Rri5avL1aZ6G1sF9xX9IkHACDbi5d7eA==@tpweb3.mongo.cosmos.azure.com:10255/Inventory?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@tpweb3@"));
            var connection = MongoDbConnection.FromConnectionString("mongodb://127.0.0.1:27017/Inmobiliaria");
            //var connection2 = MongoDbConnection.FromConnectionString("mongodb://tpweb3:zrBcQovBkgZmRlyGKnB9nSBV4iDbnQNVR1QqwsaHdjDBygm7Kie8F8Rri5avL1aZ6G1sF9xX9IkHACDbi5d7eA==@tpweb3.mongo.cosmos.azure.com:10255/Inventory?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@tpweb3@");
            return connection;
        }

        public MongoDbRepository _repository = new MongoDbRepository(ConectionStringMongo()); //para q solamente  pueda ver esta clase y las del paquete
        
        private IMongoCollection<Products> Collection;
        //internal MongoDbRepository _repository = new MongoDbRepository(); //para q solamente  pueda ver esta clase y las del paquete
        
        public ProductCollection()
        {
            
            //Collection = _repository.db.GetCollection<Product>("Products");
        }




        public void DeleteProduct(string id)
        {
            var producto = _repository.Products.FirstOrDefault(Product => Product.Id == new ObjectId(id));
         
                _repository.Products.Remove(producto);
                _repository.SaveChanges();
            

           
        }

        public List<Products> GetAllProducts()
        {
            return _repository.Products.AsQueryable().ToList(); // expresion en LINQ
        
        }

        public Products GetProductByID(string id)
        {
            var producto = _repository.Products.FirstOrDefault(Product => Product.Id == new ObjectId(id));
            _repository.SaveChanges();
           
            return producto;
          
        }

        public void InsertProduct(Products product)
        {
            _repository.Products.Add(product);
            _repository.SaveChanges();
           
        }

        public void UpdateProduct(Products product)
        {
            var ExistProducto = _repository.Products.FirstOrDefault(p => p.Id == product.Id);
            if(product != null)
            {
                ExistProducto.Name = product.Name;
                ExistProducto.Stock = product.Stock;
                ExistProducto.Category = product.Category;
                _repository.SaveChanges();

            }
          
          
            
        }

    }
}
