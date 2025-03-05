using Eximia.CreditoConsignado.Domain.Services;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace Eximia.CreditoConsignado.ExternalServices
{
    public class ExternalService : IExternalService
    {
        static readonly HttpClient httpClient = new HttpClient();

        public ExternalService(IConfiguration configuration)
        {
            if (httpClient.BaseAddress == null)
                httpClient.BaseAddress = new Uri(configuration["ScoreService:BaseAddress"]);
        }

        public async Task<bool> GetAgenteAsync(Guid id, CancellationToken cancellationToken)
        {
            // Chamada para serviço terceiro que traz a validade do agente.
            using var response = await httpClient.PostAsync("gov/agente/get", JsonContent.Create(id));            

            return await response.Content.ReadFromJsonAsync<bool>();
        }
    }
}
