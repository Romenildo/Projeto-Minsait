using ProjetoMinsait.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoMinsait.Models
{
    public class Passageiro : Pessoa
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [EmailAddress(ErrorMessage ="Email inválido")]
        public string? Email { get; set; }
        public bool Seguro { get; set; } = false;
        public int? Assento { get; set; }
        public TipoTarifa Tipo { get; set; }
        [JsonIgnore]
        public virtual Passagem? Passagem { get; set; }
        [JsonIgnore]
        public string NomeCompleto { get; set; } = "";

        public string GetNomeCompleto() 
        {
            return Nome + Sobrenome;
        }

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
