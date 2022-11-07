using System.ComponentModel.DataAnnotations;

namespace ProjetoMinsait.Models
{
    public class Passagem
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="O Campo de Destino é obrigatorio!")]
        public string? DestinoSaida { get; set; }
        [Required(ErrorMessage = "O Campo de Destino é obrigatorio!")] 
        public string? DestinoChegada { get; set; }
        [Required(ErrorMessage = "O Campo da hora de saída é obrigatorio!")] 
        public string? HorarioSaida { get; set; }
        [Required(ErrorMessage = "O Campo da hora de chegada é obrigatorio!")]
        public string? HorarioChegada { get; set; }
        [Required(ErrorMessage = "O Campo de Preco da Passagem é obrigatorio!")]
        public string? PrecoPassagem { get; set; }
        public Guid PassageiroId { get; set; }
        public Passageiro? Passageiro { get; set; }


    }
}
