namespace Eximia.CreditoConsignado.Domain.Services
{
    public interface IInssService
    {
        Task<bool> RealizarAverbacaoAsync(string cpf, decimal valor);
    }
}
