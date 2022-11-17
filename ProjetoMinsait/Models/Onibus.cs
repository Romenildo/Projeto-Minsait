using ProjetoMinsait.Models.Dtos;
using System.Text.Json.Serialization;

namespace ProjetoMinsait.Models
{
    public class Onibus
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string? NomeViacao { get; set; }
        [JsonIgnore]
        public virtual Cobrador? Cobrador { get; set; }
        [JsonIgnore]
        public virtual Motorista? Motorista { get; set; }
        [JsonIgnore]
        public virtual Passagem? Passagem { get; set; }
    }
}
