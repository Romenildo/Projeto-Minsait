using Microsoft.EntityFrameworkCore;
using ProjetoMinsait.Data.Map;
using ProjetoMinsait.Models;

namespace ProjetoMinsait.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
        }

        public DbSet<Motorista>? Motoristas { get; set; }
        public DbSet<Cobrador>? Cobradores { get; set; }
        public DbSet<Passageiro>? Passageiros { get; set; }
        public DbSet<Onibus>? Onibus { get; set; }
        public DbSet<Passagem>? Passagem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MotoristaMap());
            modelBuilder.ApplyConfiguration(new CobradorMap());
            modelBuilder.ApplyConfiguration(new PassageiroMap());
            modelBuilder.ApplyConfiguration(new OnibusMap());
            modelBuilder.ApplyConfiguration(new PassagemMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
