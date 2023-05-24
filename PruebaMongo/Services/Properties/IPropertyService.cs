using PruebaMongo.Models;

namespace PruebaMongo.Services;

public interface IPropertyService
{
    IList<Property> GetAll();

    IList<Property> RecommendProperties();

    void Save(Property properties);

    void BookDateToVisit(DateTime date);

  
}
