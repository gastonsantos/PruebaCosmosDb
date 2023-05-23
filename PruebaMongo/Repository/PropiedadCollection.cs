using MongoDB.Bson;
using MongoDB.Driver;
using MongoFramework;
using PruebaMongo.Models;

namespace PruebaMongo.Repository
{
    public class PropiedadCollection : IPropiedadCollection
    {
        private static IMongoDbConnection ConectionStringMongo()
        {
            var connection = MongoDbConnection.FromUrl(new MongoUrl("mongodb://tpweb3:zrBcQovBkgZmRlyGKnB9nSBV4iDbnQNVR1QqwsaHdjDBygm7Kie8F8Rri5avL1aZ6G1sF9xX9IkHACDbi5d7eA==@tpweb3.mongo.cosmos.azure.com:10255/Inmobiliaria?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@tpweb3@"));
           // var connection = MongoDbConnection.FromConnectionString("mongodb://127.0.0.1:27017/Inmobiliaria");
            //var connection2 = MongoDbConnection.FromConnectionString("mongodb://tpweb3:zrBcQovBkgZmRlyGKnB9nSBV4iDbnQNVR1QqwsaHdjDBygm7Kie8F8Rri5avL1aZ6G1sF9xX9IkHACDbi5d7eA==@tpweb3.mongo.cosmos.azure.com:10255/Inmobiliaria?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@tpweb3@");
            return connection;
        }

        public MongoDbRepository _repository = new MongoDbRepository(ConectionStringMongo());

        public List<Propiedades> GetAllPropiedades()
        {
            return _repository.Propiedades.AsQueryable().ToList(); // expresion en LINQ

        }

        public Propiedades GetPropiedadByID(string id)
        {
            var propiedad = _repository.Propiedades.FirstOrDefault(Prop => Prop.Id == new ObjectId(id));
            _repository.SaveChanges();

            return propiedad;

        }

        public void InsertPropiedad(Propiedades propiedad)
        {
            _repository.Propiedades.Add(propiedad);
            _repository.SaveChanges();

        }


    }
}
