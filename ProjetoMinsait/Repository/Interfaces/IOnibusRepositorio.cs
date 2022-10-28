using ProjetoMinsait.Models;

namespace ProjetoMinsait.Repository.Interfaces
{
    public interface IOnibusRepositorio
    {
        Task<List<Onibus>> BuscarTodosOnibus();
        Task<Onibus> BuscarPorID(int id);
        Task<Onibus> Adicionar(Onibus onibus);
        Task<Onibus> Atualizar(int id, Onibus onibus);
        Task<bool> Deletar(int id);
    }
}
