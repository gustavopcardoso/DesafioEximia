using Eximia.CreditoConsignado.ORM.EntityTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eximia.CreditoConsignado.ORM.Mapping
{
    public class CpfFraudeConfig : IEntityTypeConfiguration<CpfFraudeType>
    {
        public void Configure(EntityTypeBuilder<CpfFraudeType> builder)
        {
            builder.HasKey(x => x.Cpf);
        }
    }
}
