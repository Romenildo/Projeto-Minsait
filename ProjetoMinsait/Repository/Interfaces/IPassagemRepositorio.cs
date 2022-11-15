using ProjetoMinsait.Models;
using ProjetoMinsait.Models.Dtos;

namespace ProjetoMinsait.Repository.Interfaces
{
    public interface IPassagemRepositorio
    {
        Task<List<PassagemDto>> BuscarTodasPassagens();
        Task<PassagemDto> BuscarPorID(Guid id);
        Task<PassagemDto> Adicionar(Passagem passagem);
        Task<PassagemDto> Atualizar(Guid id, Passagem passagem);
        Task<Boolean> Deletar(Guid id);
    }
}
