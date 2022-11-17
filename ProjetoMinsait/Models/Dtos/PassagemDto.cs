
namespace ProjetoMinsait.Models.Dtos
{
    public class PassagemDto
    {
        public Guid Id { get; set; }
        public string? DestinoSaida { get; set; }
        public string? DestinoChegada { get; set; }
        public string? HorarioSaida { get; set; }
        public string? HorarioChegada { get; set; }
        public double PrecoPassagem { get; set; }
        public virtual Onibus? Onibus { get; set; }

        public virtual IList<Passageiro>? Passageiros { get; set; }
    }
}
