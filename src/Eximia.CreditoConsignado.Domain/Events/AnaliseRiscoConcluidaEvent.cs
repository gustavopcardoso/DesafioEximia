namespace Eximia.CreditoConsignado.Domain.Events
{
    public class AnaliseRiscoConcluidaEvent
    {
        public Guid Id { get; private set; }
        public string Cpf { get; private set; }
        public decimal Valor { get; private set; }
        public AnaliseRiscoConcluidaEvent(Guid id, string cpf, decimal valor)
        {
            Id = id;
            Cpf = cpf;
            Valor = valor;
        }
    }
}
