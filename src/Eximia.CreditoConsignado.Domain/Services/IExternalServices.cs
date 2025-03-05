namespace Eximia.CreditoConsignado.Domain.Services
{
    public interface IExternalService
    {
        Task<bool> GetAgenteAsync(Guid id, CancellationToken cancellationToken);
    }
}
