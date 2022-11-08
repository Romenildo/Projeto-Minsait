using ProjetoMinsait.Models;
using ProjetoMinsait.Models.Dtos;

namespace ProjetoMinsait.Repository.Interfaces
{
    public interface ICobradorRepositorio
    {
        Task<List<CobradorDto>> BuscarTodosCobradores();
        Task<CobradorDto> BuscarPorID(Guid id);
        Task<CobradorDto> Adicionar(Cobrador cobrador);
        Task<CobradorDto> Atualizar(Guid id, Cobrador cobrador);
        Task<string> Deletar(Guid id);
    }
}
