using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMinsait.Models;

namespace ProjetoMinsait.Data.Map
{
    public class PassageiroMap : IEntityTypeConfiguration<Passageiro>
    {
        public void Configure(EntityTypeBuilder<Passageiro> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Rg).IsRequired().HasMaxLength(12);    
        }
    }
}
