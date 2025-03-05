using Eximia.CreditoConsignado.Domain.Services;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace Eximia.CreditoConsignado.ExternalServices
{
    public class ScoreService : IScoreService
    {
        static readonly HttpClient httpClient = new HttpClient();

        public ScoreService(IConfiguration configuration)
        {
            if (httpClient.BaseAddress == null)
                httpClient.BaseAddress = new Uri(configuration["ScoreService:BaseAddress"]);
        }

        public async Task<decimal> GetScoreAsync(string cpf)
        {
            // Supondo uma comunicação com o Serasa para avaliar o score do cliente.
            using var response = await httpClient.PostAsync("serasa/score/get", JsonContent.Create(cpf));

            return await response.Content.ReadFromJsonAsync<decimal>();
        }
    }
}
