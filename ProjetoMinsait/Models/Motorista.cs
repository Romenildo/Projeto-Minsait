using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoMinsait.Models
{
    public class Motorista : Pessoa
    {
        [Required(ErrorMessage ="O Campo Cnh do motorista é obrigatorio!")]
        public string? Cnh { get; set; }
        [Range(0, 100000.00, ErrorMessage = "Campo do Sálario inválido")]
        public decimal? Salario { get; set; }

        //relacionamento
        [JsonIgnore]
        public Onibus? Onibus { get; set; }
        public int OnibusId { get; set; }
    }
}
