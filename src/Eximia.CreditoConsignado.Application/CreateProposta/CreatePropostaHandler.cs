using AutoMapper;
using Eximia.CreditoConsignado.Application.ServiceInterfaces;
using Eximia.CreditoConsignado.Application.Services;
using Eximia.CreditoConsignado.Domain.Entities;
using Eximia.CreditoConsignado.Domain.Repositories;
using MediatR;

namespace Eximia.CreditoConsignado.Application.CreateProposta
{
    public class CreatePropostaHandler(
        IPropostaRepository _propostaRepository,
        IMapper _mapper,
        ICacheService _cacheService,
        IExternalService _externalService,
        ICpfFraudeRepository _cpfFraudeRepository)
        : IRequestHandler<CreatePropostaCommand, CreatePropostaResult>
    {
        public async Task<CreatePropostaResult> Handle(CreatePropostaCommand request, CancellationToken cancellationToken)
        {
            var proposta = _mapper.Map<Proposta>(request);

            proposta.ValidarPropostaAtiva(await _propostaRepository.GetByCpfAsync(request.Cpf, cancellationToken));
            proposta.ValidarCpfAutorizado(request.Cpf, await GetCpfFraude(cancellationToken));
            proposta.ValidarAgenteHomologado(await _externalService.GetAgenteAsync(request.AgenteId, cancellationToken));

            var propostaCriada = await _propostaRepository.CreateAsync(proposta);
            var result = _mapper.Map<CreatePropostaResult>(propostaCriada);

            return result;
        }

        private async Task<List<string>> GetCpfFraude(CancellationToken cancellationToken)
        {
            string cacheKey = "cpfFraude";

            var cachedCpfFraude = await _cacheService.GetCacheValueAsync<List<string>>(cacheKey);

            if (cachedCpfFraude != null)
                return cachedCpfFraude;

            var cpfFraudeList = await _cpfFraudeRepository.GetFraudulentCpfList(cancellationToken);

            await _cacheService.SetCacheValueAsync(cacheKey, cpfFraudeList, TimeSpan.FromMinutes(5));

            return cpfFraudeList;
        }
    }
}
