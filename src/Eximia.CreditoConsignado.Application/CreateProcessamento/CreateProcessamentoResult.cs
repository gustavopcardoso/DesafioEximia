namespace Eximia.CreditoConsignado.Application.CreateProcessamento
{
    public class CreateProcessamentoResult
    {
        public Guid PropostaId { get; set; }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;
    }
}
