using System.ComponentModel.DataAnnotations;

namespace ProjetoMinsait.Models
{
    public class Cobrador : Pessoa
    {
        [Range(0,100000.00, ErrorMessage ="Campo do Sálario inválido") ]
        public decimal? Salario { get; set; }
    }
}
