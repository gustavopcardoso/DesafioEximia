namespace Eximia.CreditoConsignado.Domain.ValueObjects.Proposta
{
    public class Endereco
    {
        public string CEP { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public int Numero { get; set; }
        public string Complemento { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}
