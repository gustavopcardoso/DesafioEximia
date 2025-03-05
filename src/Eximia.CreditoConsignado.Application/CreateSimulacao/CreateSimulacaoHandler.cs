using AutoMapper;
using Eximia.CreditoConsignado.Domain.Entities;
using Eximia.CreditoConsignado.Domain.Repositories;
using MediatR;

namespace Eximia.CreditoConsignado.Application.CreateSimulacao
{
    public class CreateSimulacaoHandler(
        IPropostaRepository _propostaRepository,
        IMapper _mapper)
        : IRequestHandler<CreateSimulacaoCommand, CreateSimulacaoResult>
    {
        public async Task<CreateSimulacaoResult> Handle(CreateSimulacaoCommand request, CancellationToken cancellationToken)
        {            
            var proposta = await _propostaRepository.GetByIdAsync(request.PropostaId, cancellationToken);

            if (proposta == null)
                throw new InvalidOperationException("Proposta não encontrada");

            var simulacao = _mapper.Map<Simulacao>(request);

            simulacao.ValidarParcelamentoMaximo();            
            simulacao.ValidarValorParcelaMaximo(proposta.DadosRendimento.ValorAposentadoria);
            simulacao.ValidarDataUltimaParcela(proposta.DataNascimento);

            simulacao.ValorFinal = simulacao.CalcularValorFinal(request.Valor);
            var result = _mapper.Map<CreateSimulacaoResult>(simulacao);

            return result;
        }
    }
}
