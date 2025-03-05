namespace Eximia.CreditoConsignado.Domain.Events
{
    public class ValidacaoIniciadaEvent
    {
        public Guid Id { get; private set; }
        public decimal Valor { get; private set; }

        public ValidacaoIniciadaEvent(Guid id, decimal valor)
        {
            Id = id;
            Valor = valor;
        }
    }
}
