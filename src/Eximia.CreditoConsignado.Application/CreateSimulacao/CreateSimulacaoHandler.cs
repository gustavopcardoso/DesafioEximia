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
            var simulacao = _mapper.Map<Simulacao>(request);

            if (await _propostaRepository.GetByIdAsync(simulacao.PropostaId, cancellationToken) == null)
                throw new Exception("Proposta não encontrada");
            
            simulacao.ValidarParcelamentoMaximo();

            // Optei por dados desnormalizados.
            simulacao.ValidarValorParcelaMaximo(request.RendimentoProponente);
            simulacao.ValidarDataUltimaParcela(request.DataNascimentoProponente);

            simulacao.ValorFinal = simulacao.CalcularValorFinal(request.Valor);
            var result = _mapper.Map<CreateSimulacaoResult>(simulacao);

            return result;
        }
    }
}
