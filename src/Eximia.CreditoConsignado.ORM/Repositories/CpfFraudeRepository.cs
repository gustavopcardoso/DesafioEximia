using AutoMapper;
using Eximia.CreditoConsignado.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Eximia.CreditoConsignado.ORM.Repositories
{
    public class CpfFraudeRepository(AppDbContext _appDbContext, IMapper _mapper) : ICpfFraudeRepository
    {
        public async Task<List<string>> GetFraudulentCpfList(CancellationToken cancellationToken)
        {
            return await _appDbContext.CpfFraude.Select(c => c.Cpf).ToListAsync(cancellationToken);
        }
    }
}
