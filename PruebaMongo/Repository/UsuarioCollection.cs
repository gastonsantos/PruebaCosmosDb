using MongoDB.Bson;
using MongoDB.Driver;
using PruebaMongo.Models;

namespace PruebaMongo.Repository
{
    public class UsuarioCollection : IUsuarioCollection
    {
        internal MongoDbRepository _repository = new MongoDbRepository(); //para q solamente  pueda ver esta clase y las del paquete
        private IMongoCollection<Usuario> Collection;

        public UsuarioCollection()
        {
            //_dbContext = dbContext;
            Collection = _repository.db.GetCollection<Usuario>("Usuario");
        }

        public Usuario GetUserByNameAndPass(string name, string pass)
        {
            var filter = Builders<Usuario>.Filter.And(
            Builders<Usuario>.Filter.Eq(x => x.Nombre, name),
            Builders<Usuario>.Filter.Eq(x => x.Contraseña,pass));

           return Collection.Find(filter).FirstOrDefault();
            //return Collection.Find(new BsonDocument { { "_id", new ObjectId(id) } }).First();
        }

        public void InsertUsuario(Usuario usuario)
        {

            Collection.InsertOne(usuario);
        }


    }
}
