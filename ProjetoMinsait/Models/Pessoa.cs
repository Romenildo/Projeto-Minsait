using System.ComponentModel.DataAnnotations;

namespace ProjetoMinsait.Models
{
    public class Pessoa
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="O campo Nome é obrigatorio!")]
        public string? Nome { get; set; }
        [Required(ErrorMessage ="O campo Rg é obrigatorio!")]
        public string? Rg { get; set; }
        public string? DataNascimento { get; set; }
        public string? Contato { get; set; }



    }
}
