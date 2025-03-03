using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eximia.CreditoConsignado.Application.Services
{
    public interface IExternalService
    {
        Task<bool> GetAgenteAsync(Guid id, CancellationToken cancellationToken);
    }
}
