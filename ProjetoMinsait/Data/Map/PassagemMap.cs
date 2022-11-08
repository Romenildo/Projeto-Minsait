using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMinsait.Models;

namespace ProjetoMinsait.Data.Map
{
    public class PassagemMap : IEntityTypeConfiguration<Passagem>
    {
        public void Configure(EntityTypeBuilder<Passagem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Passageiros).WithOne(x => x.Passagem);
            builder.HasOne(x => x.Onibus).WithOne(x => x.Passagem).HasForeignKey<Passagem>(fk => fk.OnibusId);


        }
    }
}
