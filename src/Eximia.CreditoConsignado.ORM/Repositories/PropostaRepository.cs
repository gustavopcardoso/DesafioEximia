using AutoMapper;
using Eximia.CreditoConsignado.Domain.Entities;
using Eximia.CreditoConsignado.Domain.Repositories;
using Eximia.CreditoConsignado.ORM.EntityTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eximia.CreditoConsignado.ORM.Repositories
{
    public class PropostaRepository(AppDbContext _appDbContext, IMapper _mapper) : IPropostaRepository
    {
        public async Task<Proposta> CreateAsync(Proposta proposta)
        {
            var propostaEntity = _mapper.Map<PropostaType>(proposta);
            _appDbContext.Proposta.Add(propostaEntity);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<Proposta>(propostaEntity);
        }

        public async Task<Proposta?> GetByCpfAsync(string cpf, CancellationToken cancellationToken)
        {            
            var propostaEntity = await _appDbContext.Proposta.FirstOrDefaultAsync(p => p.Cpf == cpf, cancellationToken);
            return _mapper.Map<Proposta>(propostaEntity);
        }        
    }
}
