using System.ComponentModel.DataAnnotations;

namespace ProjetoMinsait.Models
{
    public class Pessoa
    {
        [Required(ErrorMessage ="O campo Nome é obrigatorio!")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "O campo Sobrenome é obrigatorio!")]
        public string? Sobrenome { get; set; }
        [Required(ErrorMessage ="O campo Rg é obrigatorio!")]
        public string? Rg { get; set; }
        public string? DataNascimento { get; set; }
        public string? Contato { get; set; }



    }
}
