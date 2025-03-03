using Eximia.CreditoConsignado.Domain.Enums;
using Eximia.CreditoConsignado.Domain.Exceptions;
using Eximia.CreditoConsignado.Domain.ValueObjects.Proposta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eximia.CreditoConsignado.Domain.Entities
{
    public class Proposta
    {
        public Guid Id { get; set; }
        public Guid AgenteId { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; } = new DateTime();
        public DadosRendimento DadosRendimento { get; set; } = new DadosRendimento();
        public Endereco Endereco { get; set; } = new Endereco();
        public Contato Contato { get; set; } = new Contato();

        public StatusPropostaEnum Status { get; set; } = StatusPropostaEnum.EmAnalise;

        public Proposta()
        {
            Id = Guid.NewGuid();

            if (DataNascimento > DateTime.Now)
                throw new DomainException("Data de nascimento não pode ser no futuro.");
        }

        public void IsPropostaAllowed(Proposta propostaExistente)
        {
            if (propostaExistente == null)
                return;

            if (propostaExistente.Status == StatusPropostaEnum.EmAnalise)
                throw new DomainException("Proponente já possui proposta ativa.");
        }

        public void IsCpfAllowed(string cpf, List<string> fraudulentCpfList)
        {
            if (fraudulentCpfList != null && fraudulentCpfList.Contains(cpf))
                throw new DomainException("CPF não autorizado.");
        }

        public void IsAgenteAllowed(bool isAllowed)
        {
            if (!isAllowed)
                throw new DomainException("Agente não autorizado.");
        }        
    }
}
