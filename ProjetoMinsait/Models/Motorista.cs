using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoMinsait.Models
{
    public class Motorista : Pessoa
    {
        [Required(ErrorMessage ="O Campo Cnh do motorista é obrigatorio!")]
        public string? Cnh { get; set; }
        public string? Salario { get; set; }
        public Guid MotoristaOnibusId { get; set; }
        public Onibus? MotoristaOnibus { get; set; }
        
    }
}
