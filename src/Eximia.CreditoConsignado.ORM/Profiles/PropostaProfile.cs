using AutoMapper;
using Eximia.CreditoConsignado.Domain.Entities;
using Eximia.CreditoConsignado.ORM.EntityTypes;

namespace Eximia.CreditoConsignado.ORM.Profiles
{
    public class PropostaProfile : Profile
    {
        public PropostaProfile() 
        {
            CreateMap<PropostaType, Proposta>();
            CreateMap<Proposta, PropostaType>();
        }
    }
}
