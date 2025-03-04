namespace Eximia.CreditoConsignado.Controllers.Simulacao.CreateSimulacao
{
    public class CreateSimulacaoRequest
    {
        public Guid PropostaId { get; set; }
        public decimal Valor { get; set; }
        public int Parcelas { get; set; }
        public decimal RendimentoProponente { get; set; }
        public DateTime DataNascimentoProponente { get; set; }
    }
}
