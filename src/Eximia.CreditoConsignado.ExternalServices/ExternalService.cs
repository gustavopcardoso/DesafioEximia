using Eximia.CreditoConsignado.Application.Services;

namespace Eximia.CreditoConsignado.ExternalServices
{
    public class ExternalService : IExternalService
    {
        public Task<bool> GetAgenteAsync(Guid id, CancellationToken cancellationToken)
        {
            // Chamada para serviço terceiro que traz a validade do agente.
            return Task.FromResult(true);
        }
    }
}
