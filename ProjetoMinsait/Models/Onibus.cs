namespace ProjetoMinsait.Models
{
    public class Onibus
    {
        public int Id { get; set; }
        public Motorista? Motorista { get; set; }
        public Cobrador? Cobrador { get; set; }
        public List<Passageiro>? PassageiroList { get; set; }

    }
}
