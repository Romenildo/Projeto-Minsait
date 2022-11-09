using ProjetoMinsait.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoMinsait.Models
{
    public class Passageiro : Pessoa
    {
        [EmailAddress(ErrorMessage ="Email inválido")]
        public string? Email { get; set; }
        public bool Seguro { get; set; } = false;
        public int? Assento { get; set; }
        public TipoTarifa Tipo { get; set; }
        [JsonIgnore]
        public virtual Passagem? Passagem { get; set; }
        [JsonIgnore]
        public double ValorPassagem { get; set; } = 0.0;
        

        public double CalcularValorPassagem(double valorTotal) 
        {
            if (Seguro) 
            {
                valorTotal += 4.50;
            }
            if (Tipo.Equals((TipoTarifa)2)) 
            {
                valorTotal /= 2;
            }
            return valorTotal;
        }



    }
}
