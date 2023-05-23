using MongoDB.Driver;
using MongoFramework;

namespace PruebaMongo.Repository;

public static class ConnectionFactory
{
    public static IMongoDbConnection GetConnection()
    {
        return MongoDbConnection.FromUrl(new MongoUrl("mongodb://tpweb3:zrBcQovBkgZmRlyGKnB9nSBV4iDbnQNVR1QqwsaHdjDBygm7Kie8F8Rri5avL1aZ6G1sF9xX9IkHACDbi5d7eA==@tpweb3.mongo.cosmos.azure.com:10255/Inmobiliaria?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@tpweb3@"));
    }
}