using ProjetoMinsait.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoMinsait.Models
{
    public class Passageiro : Pessoa
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [EmailAddress(ErrorMessage ="Email inválido")]
        public string? Email { get; set; }
        public bool? Seguro { get; set; }
        public int? Assento { get; set; }
        public TipoTarifa Tipo { get; set; }

    }
}
