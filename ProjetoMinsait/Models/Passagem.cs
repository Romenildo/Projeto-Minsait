using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoMinsait.Models
{
    public class Passagem
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [Required(ErrorMessage ="O Campo de Destino é obrigatorio!")]
        public string? DestinoSaida { get; set; }
        [Required(ErrorMessage = "O Campo de Destino é obrigatorio!")] 
        public string? DestinoChegada { get; set; }
        [Required(ErrorMessage = "O Campo da hora de saída é obrigatorio!")] 
        public string? HorarioSaida { get; set; }
        [Required(ErrorMessage = "O Campo da hora de chegada é obrigatorio!")]
        public string? HorarioChegada { get; set; }
        [Required(ErrorMessage = "O Campo de Preco da Passagem é obrigatorio!")]
        public double PrecoPassagem { get; set; } = 0.0;
        [JsonIgnore]
        public virtual IList<Passageiro>? Passageiros { get; set; }
        [JsonIgnore]
        public Guid? OnibusId { get; set; }
        [JsonIgnore]
        public virtual Onibus? Onibus { get; set; }


    }
}
