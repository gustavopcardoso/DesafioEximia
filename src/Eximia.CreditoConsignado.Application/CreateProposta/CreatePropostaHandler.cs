using AutoMapper;
using Eximia.CreditoConsignado.Application.ServiceInterfaces;
using Eximia.CreditoConsignado.Application.Services;
using Eximia.CreditoConsignado.Domain.Entities;
using Eximia.CreditoConsignado.Domain.Enums;
using Eximia.CreditoConsignado.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

            proposta.IsPropostaAllowed(await _propostaRepository.GetByCpfAsync(request.CPF, cancellationToken));
            proposta.IsCpfAllowed(request.CPF, await GetFraudulentCpfList(cancellationToken));
            proposta.IsAgenteAllowed(await _externalService.GetAgenteAsync(request.AgenteId, cancellationToken));

            var createdProposta = await _propostaRepository.CreateAsync(proposta);
            var result = _mapper.Map<CreatePropostaResult>(createdProposta);

            return result;
        }

        private async Task<List<string>> GetFraudulentCpfList(CancellationToken cancellationToken)
        {
            string cacheKey = "listFraudulentCpf";

            var cachedFraudulentCpfList = await _cacheService.GetCacheValueAsync<List<string>>(cacheKey);

            if (cachedFraudulentCpfList != null)
                return cachedFraudulentCpfList;

            var fraudulentCpfList = await _cpfFraudeRepository.GetFraudulentCpfList(cancellationToken);

            await _cacheService.SetCacheValueAsync(cacheKey, fraudulentCpfList, TimeSpan.FromMinutes(5));

            return fraudulentCpfList;
        }
    }
}
