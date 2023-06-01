using MongoDB.Driver;
using MongoFramework;
using PruebaMongo.Models;
using System.Xml;

namespace PruebaMongo.Repository;

public class AppContext : MongoDbContext
{
    //public MongoClient client;
    //public IMongoDatabase db;

    public AppContext(IMongoDbConnection connection) : base(connection)  {}

     

    public MongoDbSet<Property> Propiedades { get; set; }
    public MongoDbSet<Agente> Agentes { get; set; }
    public MongoDbSet<User> Users { get; set; }
    public MongoDbSet<Contacto> Messages { get; set; }

    


}
