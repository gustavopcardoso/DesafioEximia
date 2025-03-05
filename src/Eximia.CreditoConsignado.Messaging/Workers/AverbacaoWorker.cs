using Eximia.CreditoConsignado.Domain.Repositories;
using Eximia.CreditoConsignado.Domain.Services;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using Eximia.CreditoConsignado.Domain.Events;

namespace Eximia.CreditoConsignado.Messaging.Workers
{
    public class AverbacaoWorker(
        MessageBrokerService _messageBrokerService,
        IPropostaRepository _propostaRepository,
        IInssService _inssService)
    {
        public async Task Start()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: "averbacao_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var eventObj = JsonSerializer.Deserialize<AnaliseRiscoConcluidaEvent>(message);

                try
                {
                    bool sucesso = await _inssService.RealizarAverbacaoAsync(eventObj.Cpf, eventObj.Valor);
                    if (!sucesso)
                        throw new Exception("Erro durante processo");

                    _messageBrokerService.Publish(new AverbacaoCompletedEvent(eventObj.Id), "contrato_queue");
                }
                catch
                {
                    await channel.BasicNackAsync(ea.DeliveryTag, false, true);
                }

                await channel.BasicConsumeAsync(queue: "averbacao_queue", autoAck: false, consumer: consumer);
            };
        }
    }
}
