using AutoMapper;
using Eximia.CreditoConsignado.Application.CreateProcessamento;

namespace Eximia.CreditoConsignado.Controllers.Processamento.CreateProcessamento
{
    public class CreateProcessamentoProfile : Profile
    {
        public CreateProcessamentoProfile()
        {
            CreateMap<CreateProcessamentoRequest, CreateProcessamentoCommand>();
            CreateMap<CreateProcessamentoResult, CreateProcessamentoResponse>();
        }
    }
}
