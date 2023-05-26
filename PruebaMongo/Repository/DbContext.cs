using MongoDB.Driver;
using MongoFramework;
using PruebaMongo.Models;

namespace PruebaMongo.Repository;

public class DbContext : MongoDbContext
{
    public MongoClient client;
    public IMongoDatabase db;

    public DbContext(IMongoDbConnection connection) : base(connection)  {}

     
    public MongoDbSet<Property> Propiedades { get; set; }
    public MongoDbSet<User> Users { get; set; }
}
