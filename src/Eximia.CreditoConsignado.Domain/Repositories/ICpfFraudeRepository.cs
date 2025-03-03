using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eximia.CreditoConsignado.Domain.Repositories
{
    public interface ICpfFraudeRepository
    {
        Task<List<string>> GetFraudulentCpfList(CancellationToken cancellationToken);
    }
}
