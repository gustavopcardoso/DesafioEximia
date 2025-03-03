using AutoMapper;
using Eximia.CreditoConsignado.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
