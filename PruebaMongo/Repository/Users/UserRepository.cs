using MongoDB.Bson;
using PruebaMongo.Models;

namespace PruebaMongo.Repository.Users;

public class UserRepository : IUserRepository
{
    private readonly AppContext _context;

    public UserRepository()
    {
        this._context = new(ConnectionFactory.GetConnection());
    }

    public User? GetUserById(string id)
    {
        return _context.Users.FirstOrDefault(user => user.Id == ObjectId.Parse(id));
    }

    public void UpdateUser(User user)
    {
        this._context.Users.Update(user);
    }

    public void Insert(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
}
