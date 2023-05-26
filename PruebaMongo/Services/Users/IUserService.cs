using MongoDB.Bson;
using PruebaMongo.Models;

namespace PruebaMongo.Services.Users;

public interface IUserService
{

    User GetUserById(string id);

    void Save (User user);

    void MarkPropertyAsFavourite(Property property);

    void BookDateToVisitProperty(DateOnly bookedDate, Property property);
}
