using AutoMapper;
using Eximia.CreditoConsignado.Domain.Entities;
using Eximia.CreditoConsignado.ORM.EntityTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
