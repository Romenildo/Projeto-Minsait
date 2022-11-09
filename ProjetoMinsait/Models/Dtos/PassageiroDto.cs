
namespace ProjetoMinsait.Models.Dtos
{
    public class PassageiroDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Rg { get; set; }
        public string? DataNascimento { get; set; }
        public string? Contato { get; set; }
        public string? Email { get; set; }
        public bool? Seguro { get; set; }
        public int? Assento { get; set; }
        public Passagem? Passagem { get; set; }
        public double ValorPassagem { get; set; }
    }
}
