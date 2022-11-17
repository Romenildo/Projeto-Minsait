using ProjetoMinsait.Models;
using ProjetoMinsait.Models.Dtos;

namespace ProjetoMinsait.Repository.Interfaces
{
    public interface IOnibusRepositorio
    {
        Task<List<OnibusDto>> BuscarTodosOnibus();
        Task<OnibusDto> BuscarPorID(Guid id);
        Task<OnibusDto> Adicionar(Onibus onibus);
        Task<OnibusDto> Atualizar(Guid id, Onibus onibus);
        Task<Boolean> Deletar(Guid id);
        Task<OnibusDto> VincularCobrador(Guid idOnibus, string nomeCompleto);
        Task<OnibusDto> VincularMotorista(Guid idOnibus, string nomeCompleto);
        Task<OnibusDto> VincularPassagem(Guid idOnibus, Guid idPassagem);
    }
}
