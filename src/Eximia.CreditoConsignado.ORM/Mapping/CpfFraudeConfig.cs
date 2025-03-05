using Eximia.CreditoConsignado.ORM.EntityTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
