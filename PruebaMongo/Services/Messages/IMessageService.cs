using PruebaMongo.Models;

namespace PruebaMongo.Services.Messages
{
    public interface IMessageService
    {
        public void SendMessage(Contacto message);
    }
}
