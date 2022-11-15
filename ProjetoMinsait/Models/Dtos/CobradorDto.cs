
namespace ProjetoMinsait.Models.Dtos
{
    public class CobradorDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Rg { get; set; }
        public string? DataNascimento { get; set; }
        public string? Contato { get; set; }
        public double Salario { get; set; }
        public string? Imagem { get; set; }
        public virtual Onibus? Onibus { get; set; }
    }
}
