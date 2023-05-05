using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;

namespace PruebaMongo.Repository;

public class MongoDbRepository : DbContext
{ 

    public MongoClient client;
    public IMongoDatabase db;


public MongoDbRepository()
{
        //client = new MongoClient("mongodb://127.0.0.1:27017/");//conectar a mongoDB
        client = new MongoClient(@"mongodb://tpweb3:zrBcQovBkgZmRlyGKnB9nSBV4iDbnQNVR1QqwsaHdjDBygm7Kie8F8Rri5avL1aZ6G1sF9xX9IkHACDbi5d7eA==@tpweb3.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@tpweb3@");//conectar a mongoDB
        db = client.GetDatabase("Inventory"); // si la base de datos no existe la crea
        /*
        string connectionString =
        @"mongodb://tpweb3:zrBcQovBkgZmRlyGKnB9nSBV4iDbnQNVR1QqwsaHdjDBygm7Kie8F8Rri5avL1aZ6G1sF9xX9IkHACDbi5d7eA==@tpweb3.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@tpweb3@";
        MongoClientSettings settings = MongoClientSettings.FromUrl(
          new MongoUrl(connectionString)
        );
        settings.SslSettings =
        new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
        var mongoClient = new MongoClient(settings);
        */
    }
    
}
