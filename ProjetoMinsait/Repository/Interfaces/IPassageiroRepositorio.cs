using ProjetoMinsait.Models;
using ProjetoMinsait.Models.Dtos;

namespace ProjetoMinsait.Repository.Interfaces
{
    public interface IPassageiroRepositorio
    {
        Task<List<PassageiroDto>> BuscarTodosPassageiros();
        Task<PassageiroDto> BuscarPorID(Guid id);
        Task<PassageiroDto> Adicionar(Passageiro passageiro);
        Task<PassageiroDto> Atualizar(Guid id, Passageiro passageiro);
        Task<Boolean> Deletar(Guid id);
        Task<string> ComprarPassagem(string nomePassageiro, Guid idPassagem);
        Task<string> CancelarPassagem(string nomePassageiro, Guid idPassagem);
    }
}
