namespace Eximia.CreditoConsignado.Application.CreateSimulacao
{
    public class CreateSimulacaoResult
    {
        public Guid Id { get; set; }        
        public decimal Valor { get; set; }
        public int Parcelas { get; set; }
        public decimal ValorFinal { get; set; }
    }
}
