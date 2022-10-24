﻿using Microsoft.EntityFrameworkCore;
using ProjetoMinsait.Models;

namespace ProjetoMinsait.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
        }

        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Cobrador> Cobradores { get; set; }
        public DbSet<Passageiro> Passageiros { get; set; }
        public DbSet<Onibus> Onibus { get; set; }
        public DbSet<Passagem> passagem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }
}
