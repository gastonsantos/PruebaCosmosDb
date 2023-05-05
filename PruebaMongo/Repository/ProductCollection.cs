using MongoDB.Bson;
using MongoDB.Driver;
using PruebaMongo.Models;

namespace PruebaMongo.Repository
{
    public class ProductCollection : IProductCollection
    {
        //readonly MongoDbRepository _dbContext;
        internal MongoDbRepository _repository = new MongoDbRepository(); //para q solamente  pueda ver esta clase y las del paquete
        private IMongoCollection<Product> Collection;
        public ProductCollection()
        {
            //_dbContext = dbContext;
            Collection = _repository.db.GetCollection<Product>("Products");

            // _repository = new MongoDBRepository();
        }

        public void DeleteProduct(string id)
        {
            var filtrer = Builders<Product>.Filter.Eq(s => s.Id, new ObjectId(id));
            Collection.DeleteOne(filtrer);
        }

        public List<Product> GetAllProducts()
        {
            return Collection.Find(new BsonDocument()).ToList(); //new BsonDocument() manda un documento vacio
        }

        public Product GetProductByID(string id)
        {
            return Collection.Find(new BsonDocument { { "_id", new ObjectId(id) } }).First();
        }

        public void InsertProduct(Product product)
        {

            Collection.InsertOne(product);
        }

        public void UpdateProduct(Product product)
        {

            var filtrer = Builders<Product>.Filter.Eq(s => s.Id, product.Id);
            Collection.ReplaceOne(filtrer, product);
        }

    }
}
