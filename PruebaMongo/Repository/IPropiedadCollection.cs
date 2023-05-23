using PruebaMongo.Models;

namespace PruebaMongo.Repository;

public interface IPropiedadCollection
{
    public List<Propiedades> GetAllPropiedades();
    public Propiedades GetPropiedadByID(string id);
    public void InsertPropiedad(Propiedades propiedad);
}
