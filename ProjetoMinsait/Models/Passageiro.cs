using ProjetoMinsait.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMinsait.Models
{
    public class Passageiro : Pessoa
    {
        [EmailAddress(ErrorMessage ="Email inválido")]
        public string? Email { get; set; }
        public bool? Seguro { get; set; }
        public int? Assento { get; set; }
        public TipoTarifa Tipo { get; set; }
        public Guid OnibusId { get; set; }
        public Onibus? Onibus { get; set; }
        public Passagem? Passagem { get; set; }
    }
}
