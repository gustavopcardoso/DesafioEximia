namespace Eximia.CreditoConsignado.Controllers.Proposta.CreateProposta
{
    public class CreatePropostaRequest
    {
        public string CPF { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public DadosRendimentoRequest DadosRendimento { get; set; } = new DadosRendimentoRequest();
        public EnderecoRequest Endereco { get; set; } = new EnderecoRequest();
        public ContatoRequest Contato { get; set; } = new ContatoRequest();
    }

    public class DadosRendimentoRequest
    {
        public string NumeroINSS { get; set; } = string.Empty;
        public decimal ValorAposentadoria { get; set; } 
    }

    public class EnderecoRequest
    {
        public string CEP { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;        
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }

    public class ContatoRequest
    {
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
