using Eximia.CreditoConsignado.Domain.ValueObjects.Proposta;
using MediatR;

namespace Eximia.CreditoConsignado.Application.CreateProposta
{
    public class CreatePropostaCommand : IRequest<CreatePropostaResult>
    {
        public Guid AgenteId { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public DadosRendimento DadosRendimento { get; set; } = new DadosRendimento();
        public Endereco Endereco { get; set; } = new Endereco();
        public Contato Contato { get; set; } = new Contato();
    }
}
