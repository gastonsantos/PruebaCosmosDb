using MongoFramework;
using PruebaMongo.Models;

namespace PruebaMongo.Repository.Messages;

public interface IMessageRepository
{
    public void SendMessage(Contacto message);
}
