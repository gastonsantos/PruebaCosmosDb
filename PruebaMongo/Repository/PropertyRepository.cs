using MongoDB.Bson;
using MongoDB.Driver;
using PruebaMongo.Models;

namespace PruebaMongo.Repository;

public class PropertyRepository : IPropertyRepository
{
    private readonly AppContext _context;

    public PropertyRepository()
    {
        _context = new(ConnectionFactory.GetConnection());
    }

    public List<Property> GetAllPropiedades()
    {
        var properties = _context.Propiedades.AsQueryable().ToList();//expresiones LINQ

        return properties; 
    }

    public Property GetPropiedadByID(string id)
    {
        var propiedad = _context.Propiedades.FirstOrDefault(Prop => Prop.Id == new ObjectId(id));
        _context.SaveChanges();

        return propiedad;
    }

    public void InsertPropiedad(Property propiedad)
    {
        _context.Propiedades.Add(propiedad);
        _context.SaveChanges();
    }
}
