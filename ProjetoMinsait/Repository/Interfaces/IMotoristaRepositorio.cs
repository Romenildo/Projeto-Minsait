using ProjetoMinsait.Models;

namespace ProjetoMinsait.Repository.Interfaces
{
    public interface IMotoristaRepositorio
    {
        Task<List<Motorista>> BuscarTodosMotoristas();
        Task<Motorista> BuscarPorID(Guid id);
        Task<Motorista> Adicionar(Motorista motorista);
        Task<Motorista> Atualizar(Guid id, Motorista motorista);
        Task<bool> Deletar(Guid id);
    }
}
