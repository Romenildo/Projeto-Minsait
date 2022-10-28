﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMinsait.Models;

namespace ProjetoMinsait.Data.Map
{
    public class CobradorMap : IEntityTypeConfiguration<Cobrador>
    {
        public void Configure(EntityTypeBuilder<Cobrador> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Rg).IsRequired().HasMaxLength(12);    
        }
    }
}
