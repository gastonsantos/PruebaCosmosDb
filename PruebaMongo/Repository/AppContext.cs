using MongoDB.Driver;
using MongoFramework;
using PruebaMongo.Models;

namespace PruebaMongo.Repository;

public class AppContext : MongoDbContext
{
    public MongoClient client;
    public IMongoDatabase db;

    public AppContext(IMongoDbConnection connection) : base(connection)  {}

     

    public MongoDbSet<Property> Propiedades { get; set; } // Busca la collection con este nombre si no existe la crea

    public MongoDbSet<Agente> Agentes { get; set; }


}
