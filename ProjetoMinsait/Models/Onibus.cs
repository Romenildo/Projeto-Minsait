namespace ProjetoMinsait.Models
{
    public class Onibus
    {
        public Guid Id { get; set; }
        public Motorista? Motorista { get; set; }
        //public Cobrador? Cobrador { get; set; }
        public IList<Passageiro> ListaPassageiros { get; set; } = new List<Passageiro>();

    }
}
