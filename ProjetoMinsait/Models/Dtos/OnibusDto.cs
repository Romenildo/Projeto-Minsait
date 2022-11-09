
namespace ProjetoMinsait.Models.Dtos
{
    public class OnibusDto
    {
        public Guid Id { get; set; }
        public string? NomeViacao { get; set; }
        public virtual Cobrador? Cobrador { get; set; }
        public virtual Motorista? Motorista { get; set; }
        public virtual Passagem? Passagem { get; set; }
    }
}
