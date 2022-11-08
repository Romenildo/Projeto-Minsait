using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMinsait.Models;

namespace ProjetoMinsait.Data.Map
{
    public class MotoristaMap : IEntityTypeConfiguration<Motorista>
    {
        public void Configure(EntityTypeBuilder<Motorista> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Sobrenome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Rg).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Cnh).IsRequired().HasMaxLength(12);
            builder.HasOne(x => x.Onibus).WithOne(x => x.Motorista).HasForeignKey<Motorista>(fk => fk.OnibusId);

        }
    }
}
