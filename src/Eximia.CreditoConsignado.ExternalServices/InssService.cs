using Eximia.CreditoConsignado.Domain.Services;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace Eximia.CreditoConsignado.ExternalServices
{
    public class InssService : IInssService
    {
        static readonly HttpClient httpClient = new HttpClient();

        public InssService(IConfiguration configuration)
        {
            if (httpClient.BaseAddress == null)
                httpClient.BaseAddress = new Uri(configuration["ScoreService:BaseAddress"]);
        }

        public async Task<bool> RealizarAverbacaoAsync(string cpf, decimal valor)
        {
            // Supondo uma comunicação com o INSS para avaliar o score do cliente.
            using var response = await httpClient.PostAsync("inss/averbacao/", JsonContent.Create(cpf));

            return await response.Content.ReadFromJsonAsync<bool>(); ;
        }
    }
}
