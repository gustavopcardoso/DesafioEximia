using AutoMapper;
using Eximia.CreditoConsignado.Application.CreateSimulacao;

namespace Eximia.CreditoConsignado.Controllers.Simulacao.CreateSimulacao
{
    public class CreateSimulacaoProfile : Profile
    {
        public CreateSimulacaoProfile()
        {
            CreateMap<CreateSimulacaoRequest, CreateSimulacaoCommand>();
            CreateMap<CreateSimulacaoResult, CreateSimulacaoResponse>();
        }
    }
}
