using ProjetoMinsait.Models;

namespace ProjetoMinsait.Repository.Interfaces
{
    public interface IPassageiroRepositorio
    {
        Task<List<Passageiro>> BuscarTodosPassageiros();
        Task<Passageiro> BuscarPorID(Guid id);
        Task<Passageiro> Adicionar(Passageiro passageiro);
        Task<Passageiro> Atualizar(Guid id, Passageiro passageiro);
        Task<bool> Deletar(Guid id);
    }
}
