using Eximia.CreditoConsignado.Domain.ValueObjects.Proposta;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eximia.CreditoConsignado.Application.CreateProposta
{
    public class CreatePropostaCommand : IRequest<CreatePropostaResult>
    {
        public Guid AgenteId { get; set; }
        public string CPF { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public DadosRendimento DadosRendimento { get; set; } = new DadosRendimento();
        public Endereco Endereco { get; set; } = new Endereco();
        public Contato Contato { get; set; } = new Contato();
    }
}
