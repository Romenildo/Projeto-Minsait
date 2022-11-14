using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoMinsait.Models
{
    public class Motorista : Pessoa
    {
        [Required(ErrorMessage ="O Campo Cnh do motorista é obrigatorio!")]
        public string? Cnh { get; set; }
        public string Imagem { get; set; } = "";
        public double Salario { get; set; } = 0.0;
        [JsonIgnore]
        public Guid? OnibusId { get; set; }
        [JsonIgnore]
        public virtual Onibus? Onibus { get; set; }
    }
}
