using AutoMapper;
using Eximia.CreditoConsignado.Domain.Entities;

namespace Eximia.CreditoConsignado.Application.CreateSimulacao
{
    public class CreateSimulacaoProfile : Profile
    {
        public CreateSimulacaoProfile() 
        {
            CreateMap<CreateSimulacaoCommand, Simulacao>();
            CreateMap<Simulacao, CreateSimulacaoResult>();
        }
    }
}
