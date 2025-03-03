using AutoMapper;
using Eximia.CreditoConsignado.Application.CreateProposta;

namespace Eximia.CreditoConsignado.Controllers.Proposta.CreateProposta
{
    public class CreatePropostaProfile : Profile
    {
        public CreatePropostaProfile()
        { 
            CreateMap<CreatePropostaRequest, CreatePropostaCommand>();
            CreateMap<CreatePropostaResult, CreatePropostaResponse>();
        }
    }
}
