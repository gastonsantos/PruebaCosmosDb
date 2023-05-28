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
        //var properties = _context.Propiedades.AsQueryable().ToList();//Se usa el AsQueriable() para convertir la collection en un objeto IQueryable<Property>.
        //Esto permite usar expresionesd LINQ adicionales sobre la consulta, como filtros y proyecciones antes de ejecutarla
        var properties = _context.Propiedades.ToList();
        return properties; 
    }

    public Property GetPropiedadByID(string id)
    {
        var propiedad = _context.Propiedades.FirstOrDefault(Prop => Prop.Id == new ObjectId(id));
        //_context.SaveChanges();

        return propiedad;
    }

    public void InsertPropiedad(Property propiedad)
    {
        _context.Propiedades.Add(propiedad);
        _context.SaveChanges();
    }

    public List<string> getAllState()
    {
        var states = _context.Propiedades.
            Select(p => p.Ubicacion.Provincia).
            Distinct().
            ToList();

       // _context.SaveChanges();
        return states;
    }
    public List<string> getAllLocation()
    {
        var states = _context.Propiedades
            .Select(p => p.Ubicacion.Localidad)
            .Distinct()
            .ToList();
        //_context.SaveChanges();
        return states;
    }

    public List<Property> searchProperty(string state, string location, string operation)
    {
        IQueryable<Property> query = _context.Propiedades; //la convierte en un IQuerible para poder ponerle
        //expresiones LINQ adicionales, como los filtros//
      

        if (!string.IsNullOrEmpty(state))
        {
            query = query.Where(p => p.Ubicacion.Provincia == state);
        }

        if (!string.IsNullOrEmpty(location))
        {
            query = query.Where(p => p.Ubicacion.Localidad == location);
        }

        if (!string.IsNullOrEmpty(operation))
        {
            query = query.Where(p => p.Operacion == operation);
        }

        List<Property> properties = query.ToList();

        return properties;
    }
}
