using PruebaMongo.Models;

namespace PruebaMongo.Repository.Messages;

public class MessageRepository : IMessageRepository
{
    private readonly AppContext _context;

    public MessageRepository()
    {
        this._context = new(ConnectionFactory.GetConnection());
    }

    public void SendMessage(Contacto message)
    {
        _context.Messages.Add(message);
        _context.SaveChanges();
    }
}
