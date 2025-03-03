using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eximia.CreditoConsignado.ORM.EntityTypes
{
    public class PropostaType
    {
        public Guid Id { get; set; }
        public string Cpf { get; set; } = string.Empty;
    }
}
