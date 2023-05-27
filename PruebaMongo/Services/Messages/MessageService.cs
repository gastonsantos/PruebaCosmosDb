using PruebaMongo.Models;
using PruebaMongo.Repository;
using PruebaMongo.Repository.Messages;

namespace PruebaMongo.Services.Messages
{
    public class MessageService: IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            this._messageRepository = messageRepository;
        }

        public void SendMessage(Contacto message)
        {
            this._messageRepository.SendMessage(message);
        }
    }
}
