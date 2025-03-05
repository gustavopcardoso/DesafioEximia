using Eximia.CreditoConsignado.Domain.Enums;
using Eximia.CreditoConsignado.Domain.Events;
using Eximia.CreditoConsignado.Domain.Repositories;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Eximia.CreditoConsignado.Messaging.Workers
{
    public class ValidacaoWorker(MessageBrokerService _messageBrokerService, IPropostaRepository _propostaRepository)
    {
        public async Task Start()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: "validacao_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var eventObj = JsonSerializer.Deserialize<ValidacaoIniciadaEvent>(message);

                try
                {
                    // Valor fixo, não sei ao certo como funcionaria a geração desse score.
                    decimal scoreValidacao = 7.5M;

                    var proposta = await _propostaRepository.GetByIdAsync(eventObj.Id, CancellationToken.None);

                    if (scoreValidacao < 7)
                    {
                        // Persiste estado de rejeitado.                        
                        proposta.Status = StatusPropostaEnum.Reprovado;
                        await _propostaRepository.UpdateAsync(proposta);

                        // Manda para fila de rejeitados.
                        _messageBrokerService.Publish(new PropostaRejeitadaEvent(eventObj.Id), "proposta_rejeitada_queue");
                        await channel.BasicAckAsync(ea.DeliveryTag, false);
                    }
                    else
                    {
                        // Envia evento para a fila de analise de risco.
                        _messageBrokerService.Publish(new ValidacaoConcluidaEvent(eventObj.Id, proposta.Cpf, proposta.DadosRendimento.ValorAposentadoria), "analise_risco_queue");
                        await channel.BasicAckAsync(ea.DeliveryTag, false);
                    }
                }
                catch
                {
                    await channel.BasicNackAsync(ea.DeliveryTag, false, true);
                }

                await channel.BasicConsumeAsync(queue: "analise_risco_queue", autoAck: false, consumer: consumer);
            };
        }
    }
}
