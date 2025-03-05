namespace Eximia.CreditoConsignado.Domain.Services
{
    public interface IScoreService
    {
        Task<decimal> GetScoreAsync(string cpf);
    }
}
