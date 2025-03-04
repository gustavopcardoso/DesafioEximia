using AutoMapper;
using Eximia.CreditoConsignado.Application.CreateProposta;
using Eximia.CreditoConsignado.Domain.ValueObjects.Proposta;

namespace Eximia.CreditoConsignado.Controllers.Proposta.CreateProposta
{
    public class CreatePropostaProfile : Profile
    {
        public CreatePropostaProfile()
        {
            CreateMap<CreatePropostaRequest, CreatePropostaCommand>();
            CreateMap<DadosRendimentoRequest, DadosRendimento>();
            CreateMap<EnderecoRequest, Endereco>();
            CreateMap<ContatoRequest, Contato>();
            CreateMap<CreatePropostaResult, CreatePropostaResponse>();
        }
    }
}
