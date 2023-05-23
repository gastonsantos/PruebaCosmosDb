using MongoDB.Bson;
using MongoDB.Driver;
using PruebaMongo.Models;

namespace PruebaMongo.Repository;

public class PropertyRepository : IPropiedadCollection
{
    public AppContext context;

    public PropertyRepository()
    {
        context = new(ConnectionFactory.GetConnection());
    }

    public List<Propiedades> GetAllPropiedades()
    {
        return context.Propiedades.AsQueryable().ToList(); // expresion en LINQ
    }

    public Propiedades GetPropiedadByID(string id)
    {
        var propiedad = context.Propiedades.FirstOrDefault(Prop => Prop.Id == new ObjectId(id));
        context.SaveChanges();

        return propiedad;
    }

    public void InsertPropiedad(Propiedades propiedad)
    {
        context.Propiedades.Add(propiedad);
        context.SaveChanges();
    }
}
