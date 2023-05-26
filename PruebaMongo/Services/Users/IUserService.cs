using PruebaMongo.Models;

namespace PruebaMongo.Services.Users;

public interface IUserService
{
    void MarkPropertyAsFavourite(Property property);

    void BookDateToVisitProperty(DateOnly bookedDate, Property property);
}
