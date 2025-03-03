namespace Eximia.CreditoConsignado.Controllers.Simulacao.CreateSimulacao
{
    public class CreateSimulacaoRequest
    {
        public Guid PropostaId { get; set; }
        public decimal Valor { get; set; }
        public int Parcelas { get; set; }
    }
}
