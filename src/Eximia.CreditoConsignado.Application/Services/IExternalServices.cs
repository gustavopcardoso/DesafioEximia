namespace Eximia.CreditoConsignado.Application.Services
{
    public interface IExternalService
    {
        Task<bool> GetAgenteAsync(Guid id, CancellationToken cancellationToken);
    }
}
