using AutoMapper;
using Eximia.CreditoConsignado.Domain.Entities;

namespace Eximia.CreditoConsignado.Application.CreateProposta
{
    public class CreatePropostaProfile : Profile
    {
        public CreatePropostaProfile()
        {
            CreateMap<CreatePropostaCommand, Proposta>();
            CreateMap<Proposta, CreatePropostaResult>();
        }
    }
}
