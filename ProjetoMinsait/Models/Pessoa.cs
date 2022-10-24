using System.ComponentModel.DataAnnotations;

namespace ProjetoMinsait.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Rg { get; set; }
        public string? DataNascimento { get; set; }
        public string? Contato { get; set; }



    }
}
