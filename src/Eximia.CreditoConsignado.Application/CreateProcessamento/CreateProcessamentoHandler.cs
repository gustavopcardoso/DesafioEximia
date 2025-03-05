using Eximia.CreditoConsignado.Domain.Enums;
using Eximia.CreditoConsignado.Domain.Events;
using Eximia.CreditoConsignado.Domain.Repositories;
using Eximia.CreditoConsignado.Domain.Services;
using MediatR;

namespace Eximia.CreditoConsignado.Application.CreateProcessamento
{
    public class CreateProcessamentoHandler(
        IPropostaRepository _propostaRepository,
        IMessageBrokerService _messageBrokerService)
        : IRequestHandler<CreateProcessamentoCommand, CreateProcessamentoResult>
    {
        public async Task<CreateProcessamentoResult> Handle(CreateProcessamentoCommand request, CancellationToken cancellationToken)
        {
            // Utilizar o ID informado para buscar a proposta ativa.
            var proposta = await _propostaRepository.GetByIdAsync(request.PropostaId, cancellationToken);

            // A proposta precisa estar em estado "Criado" para ser processada.
            if (proposta == null)
                throw new InvalidOperationException("Proposta não encontrada.");

            else if (proposta.Status == StatusPropostaEnum.Reprovado)
                throw new InvalidOperationException("Proposta reprovada");

            else if (proposta.Status != StatusPropostaEnum.Criado)
                throw new InvalidOperationException("Proposta não está em estado 'Criado'.");

            // Altera o status da proposta para "Em Análise".
            proposta.SetPropostaEmAnalise();
            proposta = await _propostaRepository.UpdateAsync(proposta);

            #region TEMP
            /*
            decimal scoreValidacao = ObterScoreValidacao(proposta);
            decimal scoreRisco = await ObterScoreRisco(proposta);

            proposta.ValidarScores(scoreValidacao, scoreRisco);

            if (proposta.Status == StatusPropostaEnum.Reprovado)
            {
                // Persiste a alteração do status da proposta.
                proposta = await _propostaRepository.UpdateAsync(proposta);

                return new CreateProcessamentoResult { Sucesso = false };
            }*/
            #endregion

            // Envia evento para fila de processamento.
            _messageBrokerService.Publish(new ValidacaoIniciadaEvent(proposta.Id, request.Valor), "validacao_queue");

            return new CreateProcessamentoResult 
            { 
                Sucesso = true,
                Mensagem = "Processamento iniciado com sucesso."
            };
        }
    }
}
