using MongoDB.Driver;
using MongoFramework;
using PruebaMongo.Models;

namespace PruebaMongo.Repository;

public class AppContext : MongoDbContext
{
    public MongoClient client;
    public IMongoDatabase db;

    public AppContext(IMongoDbConnection connection) : base(connection)  {}

    public MongoDbSet<Products> Products { get; set; } //Buscar la Collection con este nombre si no existe la crea

    public MongoDbSet<Property> Propiedades { get; set; } // Busca la collection con este nombre si no existe la crea


}
