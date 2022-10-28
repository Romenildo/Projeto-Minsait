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
                
        }
    }
}
