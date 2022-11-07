using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMinsait.Models;

namespace ProjetoMinsait.Data.Map
{
    public class OnibusMap : IEntityTypeConfiguration<Onibus>
    {
        public void Configure(EntityTypeBuilder<Onibus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.ListaPassageiros).WithOne(x => x.Onibus).HasForeignKey(p => p.OnibusId);
            builder.HasOne(x => x.Motorista).WithOne(x => x.MotoristaOnibus).HasForeignKey<Motorista>(x => x.MotoristaOnibusId);
            //builder.HasOne(x => x.Cobrador).WithOne(x => x.CobradorOnibus).HasForeignKey<Cobrador>(x => x.CobradorOnibusId);

        }
    }
}
