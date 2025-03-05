namespace Eximia.CreditoConsignado.Domain.Events
{
    public class ValidacaoConcluidaEvent
    {        
        public Guid Id { get; private set; }
        public string Cpf { get; private set; }
        public decimal Valor { get; private set; }

        public ValidacaoConcluidaEvent(Guid id, string cpf, decimal valor)
        {
            Id = id;
            Cpf = cpf;
            Valor = valor;
        }
    }
}
