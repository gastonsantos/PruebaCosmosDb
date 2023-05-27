using MongoDB.Bson;
using PruebaMongo.Models;

namespace PruebaMongo.Services.Users;

public interface IUserService
{

    User GetUserById(string id);

    void Save (User user);

    void TogglePropertyFavorite(Property property, string userId);

    void BookDateToVisitProperty(DateOnly bookedDate, Property property);
}
