using ProjetoMinsait.Models;

namespace ProjetoMinsait.Repository.Interfaces
{
    public interface IMotoristaRepositorio
    {
        Task<List<Motorista>> BuscarTodosMotoristas();
        Task<Motorista> BuscarPorID(int id);
        Task<Motorista> Adicionar(Motorista motorista);
        Task<Motorista> Atualizar(int id, Motorista motorista);
        Task<bool> Deletar(int id);
    }
}
