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

    public User GetUserById(string id)
    {
        var userFound = this._userRepository.GetUserById(id);

        return userFound is not null ? userFound : throw new Exception("User was not found.");
    }

    public void MarkPropertyAsFavourite(Property property)
    {
        throw new NotImplementedException();
    }

    public void Save (User user)
    {
        this._userRepository.Insert(user);
    }
}
