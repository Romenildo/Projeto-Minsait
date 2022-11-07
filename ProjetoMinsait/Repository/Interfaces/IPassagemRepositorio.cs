using ProjetoMinsait.Models;

namespace ProjetoMinsait.Repository.Interfaces
{
    public interface IPassagemRepositorio
    {
        Task<List<Passagem>> BuscarTodasPassagens();
        Task<Passagem> BuscarPorID(Guid id);
        Task<Passagem> Adicionar(Passagem passagem);
        Task<Passagem> Atualizar(Guid id, Passagem passagem);
        Task<bool> Deletar(Guid id);
    }
}
