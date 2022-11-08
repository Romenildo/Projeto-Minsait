using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace ProjetoMinsait.Models
{
    public class Cobrador : Pessoa
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public double Salario { get; set; } = 0.0;
        [JsonIgnore]
        public Guid? OnibusId { get; set; }
        [JsonIgnore]
        public virtual Onibus? Onibus { get; set; }
    }
}
