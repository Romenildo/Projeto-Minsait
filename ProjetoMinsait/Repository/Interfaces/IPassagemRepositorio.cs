using ProjetoMinsait.Models;

namespace ProjetoMinsait.Repository.Interfaces
{
    public interface IPassagemRepositorio
    {
        Task<List<Passagem>> BuscarTodasPassagens();
        Task<Passagem> BuscarPorID(int id);
        Task<Passagem> Adicionar(Passagem passagem);
        Task<Passagem> Atualizar(int id, Passagem passagem);
        Task<bool> Deletar(int id);
    }
}
