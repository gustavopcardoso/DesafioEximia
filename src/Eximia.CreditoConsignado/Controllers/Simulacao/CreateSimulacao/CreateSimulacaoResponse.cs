namespace Eximia.CreditoConsignado.Controllers.Simulacao.CreateSimulacao
{
    public class CreateSimulacaoResponse
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public int Parcelas { get; set; }
        public decimal ValorFinal { get; set; }
    }
}
