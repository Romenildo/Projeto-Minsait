using ProjetoMinsait.Models;
using ProjetoMinsait.Models.Dtos;

namespace ProjetoMinsait.Repository.Interfaces
{
    public interface IMotoristaRepositorio
    {
        Task<List<MotoristaDto>> BuscarTodosMotoristas();
        Task<MotoristaDto> BuscarPorID(Guid id);
        Task<MotoristaDto> Adicionar(Motorista motorista);
        Task<MotoristaDto> Atualizar(Guid id, Motorista motorista);
        Task<string> Deletar(Guid id);
    }
}
