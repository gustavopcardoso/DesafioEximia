using MediatR;

namespace Eximia.CreditoConsignado.Application.CreateSimulacao
{
    public class CreateSimulacaoCommand : IRequest<CreateSimulacaoResult>
    {
        public Guid PropostaId { get; set; }
        public decimal Valor { get; set; }
        public decimal RendimentoProponente { get; set; }
        public DateTime DataNascimentoProponente { get; set; }
        public int Parcelas { get; set; }
    }
}
