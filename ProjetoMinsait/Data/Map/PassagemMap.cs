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
               
        }
    }
}
