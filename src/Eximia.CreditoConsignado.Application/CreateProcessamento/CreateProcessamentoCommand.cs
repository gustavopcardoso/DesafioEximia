using MediatR;

namespace Eximia.CreditoConsignado.Application.CreateProcessamento
{
    public class CreateProcessamentoCommand : IRequest<CreateProcessamentoResult>
    {
        public Guid PropostaId { get; set; }
        public decimal Valor { get; set; }
    }
}
