using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eximia.CreditoConsignado.Domain.Events
{
    public class AverbacaoCompletedEvent
    {
        public Guid Id { get; private set; }

        public AverbacaoCompletedEvent(Guid id)
        {
            Id = id;
        }
    }
}
