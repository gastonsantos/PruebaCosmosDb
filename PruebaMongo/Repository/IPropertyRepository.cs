using MongoDB.Bson;
using PruebaMongo.Models;

namespace PruebaMongo.Repository;

public interface IPropertyRepository
{
    public List<Property> GetAllPropiedades();
    public Property GetPropiedadByID(string id);
    public void InsertPropiedad(Property propiedad);
    public List<string> getAllLocation();
    public List<string> getAllState();

}
