namespace Eximia.CreditoConsignado.Domain.Services
{
    public interface IMessageBrokerService
    {
        void Publish<T>(T message, string queueName);
    }
}
