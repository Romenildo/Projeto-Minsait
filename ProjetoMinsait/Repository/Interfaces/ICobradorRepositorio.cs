using ProjetoMinsait.Models;

namespace ProjetoMinsait.Repository.Interfaces
{
    public interface ICobradorRepositorio
    {
        Task<List<Cobrador>> BuscarTodosCobradores();
        Task<Cobrador> BuscarPorID(Guid id);
        Task<Cobrador> Adicionar(Cobrador cobrador);
        Task<Cobrador> Atualizar(Guid id, Cobrador cobrador);
        Task<bool> Deletar(Guid id);
    }
}
