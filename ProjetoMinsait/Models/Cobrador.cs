using System.ComponentModel.DataAnnotations;

namespace ProjetoMinsait.Models
{
    public class Cobrador : Pessoa
    {
        public string? Salario { get; set; }
        //public Guid CobradorOnibusId { get; set; }
        //public Onibus? CobradorOnibus { get; set; }
    }
}
