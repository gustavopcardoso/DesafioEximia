using Eximia.CreditoConsignado.Domain.Entities;
using Eximia.CreditoConsignado.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eximia.CreditoConsignado.Domain.Repositories
{
    public interface IPropostaRepository
    {
        Task<Proposta> CreateAsync(Proposta proposta);
        Task<Proposta> GetByCpfAsync(string cpf, CancellationToken cancellationToken);        
    }
}
