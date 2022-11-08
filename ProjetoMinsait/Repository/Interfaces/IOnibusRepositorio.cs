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
        Task<string> Deletar(Guid id);
        Task<string> VincularCobrador(Guid idOnibus, string nomeCompleto);
        Task<string> VincularMotorista(Guid idOnibus, string nomeCompleto);
        Task<string> VincularPassagem(Guid idOnibus, Guid idPassagem);
    }
}
