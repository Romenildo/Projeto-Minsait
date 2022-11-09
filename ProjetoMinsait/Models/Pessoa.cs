using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoMinsait.Models
{
    public class Pessoa
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [Required(ErrorMessage ="O campo Nome é obrigatorio!")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "O campo Sobrenome é obrigatorio!")]
        public string? Sobrenome { get; set; }
        [Required(ErrorMessage ="O campo Rg é obrigatorio!")]
        public string? Rg { get; set; }
        [Required(ErrorMessage = "O campo DataNascimento é obrigatorio!")]
        public string? DataNascimento { get; set; }
        [Required(ErrorMessage = "O campo Contato é obrigatorio!")]
        public string? Contato { get; set; }
        [JsonIgnore]
        public string NomeCompleto { get; set; } = "";
        public string GetNomeCompleto()
        {
            return Nome + Sobrenome;
        }


    }
}
