using System.Text.Json.Serialization;

namespace ProjetoMinsait.Models
{
    public class Onibus
    {
        public Guid Id { get; set; }
        [JsonIgnore]
        public virtual Cobrador? Cobrador { get; set; }
        [JsonIgnore]
        public virtual Motorista? Motorista { get; set; }
        [JsonIgnore]

        public Guid? PassagemId { get; set; }
        [JsonIgnore]
        public virtual Passagem? Passagem { get; set; }


    }
}
