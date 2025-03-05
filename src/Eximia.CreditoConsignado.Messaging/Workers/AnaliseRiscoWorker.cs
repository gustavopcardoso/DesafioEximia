using Eximia.CreditoConsignado.Domain.Repositories;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using Eximia.CreditoConsignado.Domain.Events;
using Eximia.CreditoConsignado.Domain.Services;
using Eximia.CreditoConsignado.Domain.Enums;

namespace Eximia.CreditoConsignado.Messaging.Workers
{
    public class AnaliseRiscoWorker(
        MessageBrokerService _messageBrokerService, 
        IPropostaRepository _propostaRepository,
        IScoreService _scoreService)
    {
        public async Task Start()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: "analise_risco_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var eventObj = JsonSerializer.Deserialize<ValidacaoConcluidaEvent>(message);

                try
                {
                    // Valor fixo, não sei ao certo como funcionaria a geração desse score.
                    decimal scoreRisk = await _scoreService.GetScoreAsync(eventObj.Cpf);

                    if (scoreRisk < 7)
                    {
                        // Persiste estado de rejeitado.
                        var proposta = await _propostaRepository.GetByIdAsync(eventObj.Id, CancellationToken.None);
                        proposta.Status = StatusPropostaEnum.Reprovado;
                        await _propostaRepository.UpdateAsync(proposta);

                        // Manda para fila de rejeitados.
                        _messageBrokerService.Publish(new PropostaRejeitadaEvent(eventObj.Id), "proposta_rejeitada_queue");
                        await channel.BasicAckAsync(ea.DeliveryTag, false);
                    }
                    else
                    {
                        // Envia evento para a fila de analise de risco.
                        _messageBrokerService.Publish(new AnaliseRiscoConcluidaEvent(eventObj.Id, eventObj.Cpf, eventObj.Valor), "averbacao_queue");
                        await channel.BasicAckAsync(ea.DeliveryTag, false);
                    }
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
