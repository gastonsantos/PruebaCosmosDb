using PruebaMongo.Models;

namespace PruebaMongo.Services;

public interface IPropertyService
{
    IList<Property> GetAll();

    IList<Property> RecommendProperties(User user);

    Property getPropertyById(string id);

    void Save(Property properties);  
}
