using MongoDB.Bson;

namespace PruebaMongo.Models;

public class User
{
    public ObjectId Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public IList<Property> FavouritesProperties { get; set; } = new List<Property>();

    public IList<Property> ReservedProperties { get; set; } = new List<Property>();
}