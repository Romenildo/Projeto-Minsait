using ProjetoMinsait.Models;

namespace ProjetoMinsait.Repository.Interfaces
{
    public interface IOnibusRepositorio
    {
        Task<List<Onibus>> BuscarTodosOnibus();
        Task<Onibus> BuscarPorID(Guid id);
        Task<Onibus> Adicionar(Onibus onibus);
        Task<Onibus> Atualizar(Guid id, Onibus onibus);
        Task<bool> Deletar(Guid id);
        Task<string> VincularCobrador(Guid idOnibus, string nomeCobrador);
    }
}
