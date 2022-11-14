using System.Text.Json.Serialization;

namespace ProjetoMinsait.Models
{
    public class Cobrador : Pessoa
    {
        public double Salario { get; set; } = 0.0;
        public string Imagem { get; set; } = "";
        [JsonIgnore]
        public Guid? OnibusId { get; set; }
        [JsonIgnore]
        public virtual Onibus? Onibus { get; set; }
    }
}
