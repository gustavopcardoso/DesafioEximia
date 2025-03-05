namespace Eximia.CreditoConsignado.ORM.EntityTypes
{
    public class PropostaType
    {
        // Optei por deixar apenas essas 2 colunas por enquanto.        
        public Guid Id { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
