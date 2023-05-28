using PruebaMongo.Models;

namespace PruebaMongo.Services;

public interface IPropertyService
{
    IList<Property> GetAll();

    IList<Property> RecommendProperties(User user);

    Property getPropertyById(string id);

    void Save(Property properties);

    public List<string> getAllState();

    public List<string> getAllLocation();

    public List<Property> searchProperty(string state, string location, string operation);
}
