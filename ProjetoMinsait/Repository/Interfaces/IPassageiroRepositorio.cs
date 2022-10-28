using ProjetoMinsait.Models;

namespace ProjetoMinsait.Repository.Interfaces
{
    public interface IPassageiroRepositorio
    {
        Task<List<Passageiro>> BuscarTodosPassageiros();
        Task<Passageiro> BuscarPorID(int id);
        Task<Passageiro> Adicionar(Passageiro passageiro);
        Task<Passageiro> Atualizar(int id, Passageiro passageiro);
        Task<bool> Deletar(int id);
    }
}
