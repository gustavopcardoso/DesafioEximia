using Eximia.CreditoConsignado.ORM.EntityTypes;
using Microsoft.EntityFrameworkCore;

namespace Eximia.CreditoConsignado.ORM
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<PropostaType> Proposta { get; set; }

        public DbSet<CpfFraudeType> CpfFraude { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
