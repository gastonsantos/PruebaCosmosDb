using PruebaMongo.Models;

namespace PruebaMongo.Repository.Users;

public interface IUserRepository
{
    public User? GetUserById(string id);

    public void UpdateUser(User user);
}