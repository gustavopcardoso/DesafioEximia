namespace Eximia.CreditoConsignado.Domain.Events
{
    
    public class PropostaRejeitadaEvent
    {
        public Guid Id { get; set; }
        public PropostaRejeitadaEvent(Guid id)
        {
            Id = id;
        }
    }
}
