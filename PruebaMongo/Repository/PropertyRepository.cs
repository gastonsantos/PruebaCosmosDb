using MongoDB.Bson;
using MongoDB.Driver;
using PruebaMongo.Models;

namespace PruebaMongo.Repository;

public class PropertyRepository : IPropertyRepository
{
    private AppContext context;

    public PropertyRepository()
    {
        Console.Write(ConnectionFactory.GetConnection());
        context = new(ConnectionFactory.GetConnection());
    }

    public List<Property> GetAllPropiedades()
    {
        var properties = context.Propiedades.AsQueryable().ToList();//expresiones LINQ

        return properties; 
    }

    public Property GetPropiedadByID(string id)
    {
        var propiedad = context.Propiedades.FirstOrDefault(Prop => Prop.Id == new ObjectId(id));
        context.SaveChanges();

        return propiedad;
    }

    public void InsertPropiedad(Property propiedad)
    {
        context.Propiedades.Add(propiedad);
        context.SaveChanges();
    }
}
