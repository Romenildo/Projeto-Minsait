
namespace ProjetoMinsait.Models.Dtos
{
    public class MotoristaDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Rg { get; set; }
        public string? DataNascimento { get; set; }
        public string? Contato { get; set; }
        public string? Cnh { get; set; }
        public double Salario { get; set; }
    }
}
