using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ProjetoMinsait.Data;
using ProjetoMinsait.Models;
using ProjetoMinsait.Models.Dtos;
using ProjetoMinsait.Repository.Interfaces;

namespace ProjetoMinsait.Repository
{
    public class PassagemRepositorio : IPassagemRepositorio
    {

        private readonly DataContext _dbcontext;
        private readonly IMapper _mapper;

        public PassagemRepositorio(DataContext dataContext, IMapper mapper)
        {
            _dbcontext = dataContext;
            _mapper = mapper;
        }

        public async Task<PassagemDto> BuscarPorID(Guid id)
        {
            var resultado = await _dbcontext.Passagem.FirstOrDefaultAsync(x => x.Id == id);
            var resultadoDto = _mapper.Map<PassagemDto>(resultado);
            return resultadoDto;
        }

        public async Task<List<PassagemDto>> BuscarTodasPassagens()
        {
            return await _dbcontext.Passagem
                   .Select(x => new PassagemDto { Id = x.Id, DestinoChegada =x.DestinoChegada, DestinoSaida = x.DestinoSaida, HorarioChegada = x.HorarioChegada, HorarioSaida=x.HorarioSaida, PrecoPassagem = x.PrecoPassagem })
                   .ToListAsync();
        }

        public async Task<PassagemDto> Adicionar(Passagem passagem)
        {
            passagem.Id = new Guid();
            passagem.Passageiros = new List<Passageiro>();
            await _dbcontext.Passagem.AddAsync(passagem);
            await _dbcontext.SaveChangesAsync();

            var resultadoDto = _mapper.Map<PassagemDto>(passagem);
            return resultadoDto;
        }

        public async Task<PassagemDto> Atualizar(Guid id, Passagem Passagem)
        {
            Passagem passagemBd = await _dbcontext.Passagem.FirstOrDefaultAsync(x => x.Id == id);

            if (passagemBd == null)
            {
                throw new Exception($"Usuario com Id: {id} não encontrado!");
            }

            _dbcontext.Passagem.Update(passagemBd);
            await _dbcontext.SaveChangesAsync();

            var resultadoDto = _mapper.Map<PassagemDto>(passagemBd);
            return resultadoDto;

        }

        public async Task<string> Deletar(Guid id)
        {
            Passagem passagemBd = await _dbcontext.Passagem.FirstOrDefaultAsync(x => x.Id == id);

            if (passagemBd == null)
            {
                throw new Exception($"Passagem com Id: {id} não encontrado!");
            }
            _dbcontext.Passagem.Remove(passagemBd);
            await _dbcontext.SaveChangesAsync();

            return "Passagem Deletada com sucesso!";
        }

    }
}
