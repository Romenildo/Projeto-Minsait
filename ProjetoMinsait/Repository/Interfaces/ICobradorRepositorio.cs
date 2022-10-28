using ProjetoMinsait.Models;

namespace ProjetoMinsait.Repository.Interfaces
{
    public interface ICobradorRepositorio
    {
        Task<List<Cobrador>> BuscarTodosCobradores();
        Task<Cobrador> BuscarPorID(int id);
        Task<Cobrador> Adicionar(Cobrador cobrador);
        Task<Cobrador> Atualizar(int id, Cobrador cobrador);
        Task<bool> Deletar(int id);
    }
}
