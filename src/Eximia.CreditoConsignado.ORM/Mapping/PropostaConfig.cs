using Eximia.CreditoConsignado.ORM.EntityTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eximia.CreditoConsignado.ORM.Mapping
{
    internal class PropostaConfig : IEntityTypeConfiguration<PropostaType>
    {
        public void Configure(EntityTypeBuilder<PropostaType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Cpf).IsRequired();
        }
    }
}
