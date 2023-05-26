using PruebaMongo.Models;
using PruebaMongo.Repository.Users;

namespace PruebaMongo.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService (IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    public void BookDateToVisitProperty(DateOnly bookedDate, Property property)
    {
        throw new NotImplementedException();
    }

    public void MarkPropertyAsFavourite(Property property)
    {
        throw new NotImplementedException();
    }
}
