using Eximia.CreditoConsignado.Domain.Entities;

namespace Eximia.CreditoConsignado.Domain.Repositories
{
    public interface IPropostaRepository
    {
        Task<Proposta> CreateAsync(Proposta proposta);
        Task<Proposta> UpdateAsync(Proposta proposta);
        Task<Proposta> GetByCpfAsync(string cpf, CancellationToken cancellationToken);
        Task<Proposta> GetByIdAsync(Guid id, CancellationToken cancellationToken);  
    }
}
