namespace ProjetoMinsait.Models
{
    public class Passagem
    {
        public int Id { get; set; }
        public string? DestinoSaida { get; set; }
        public string? DestinoChegada { get; set; }
        public string? HorarioSaida { get; set; }
        public string? HorarioChegada { get; set; }
        public string? Preco { get; set; }

    }
}
