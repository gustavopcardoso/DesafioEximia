using Eximia.CreditoConsignado.Domain.Services;

namespace Eximia.CreditoConsignado.Messaging
{
    public class MessageBrokerService : IMessageBrokerService
    {
        
        public void Publish<T>(T message, string queueName)
        {
            // Publica a mensagem na fila informada do RabbitMQ

            throw new NotImplementedException();
        }
    }
}
