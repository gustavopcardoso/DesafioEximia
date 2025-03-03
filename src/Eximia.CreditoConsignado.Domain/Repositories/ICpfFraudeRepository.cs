namespace Eximia.CreditoConsignado.Domain.Repositories
{
    public interface ICpfFraudeRepository
    {
        Task<List<string>> GetFraudulentCpfList(CancellationToken cancellationToken);
    }
}
