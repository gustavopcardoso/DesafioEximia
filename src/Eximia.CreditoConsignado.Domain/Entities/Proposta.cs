using Eximia.CreditoConsignado.Domain.Enums;
using Eximia.CreditoConsignado.Domain.Exceptions;
using Eximia.CreditoConsignado.Domain.ValueObjects.Proposta;

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

        public StatusPropostaEnum Status { get; set; }

        public Proposta()
        {
            Id = Guid.NewGuid();

            if (DataNascimento > DateTime.Now)
                throw new DomainException("Data de nascimento não pode ser futura.");
        }

        public void ValidarPropostaAtiva(Proposta propostaExistente)
        {
            if (propostaExistente == null)
                return;

            if (propostaExistente.Status == StatusPropostaEnum.EmAnalise)
                throw new DomainException("Proponente já possui proposta ativa.");
        }

        public void ValidarCpfAutorizado(string cpf, List<string> fraudulentCpfList)
        {
            if (fraudulentCpfList != null && fraudulentCpfList.Contains(cpf))
                throw new DomainException("CPF não autorizado. Verificar lista de CPFs fraudulentos.");
        }

        public void ValidarAgenteHomologado(bool isAllowed)
        {
            if (!isAllowed)
                throw new DomainException("Agente não autorizado para realizar operação.");
        }

        public void ValidarScores(decimal validationScore, decimal riskScore)
        {            
            if (validationScore < 7 || riskScore < 7) 
                ReprovarProposta();
        }

        public void SetPropostaCriado()
        {
            Status = StatusPropostaEnum.Criado;
        }

        public void SetPropostaEmAnalise()
        {
            Status = StatusPropostaEnum.EmAnalise;
        }

        public void ReprovarProposta()
        {
            Status = StatusPropostaEnum.Reprovado;
        }
    }
}
