using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetoMinsait.Data;
using ProjetoMinsait.Models;
using ProjetoMinsait.Models.Dtos;
using ProjetoMinsait.Repository.Interfaces;

namespace ProjetoMinsait.Repository
{
    public class MotoristaRepositorio : IMotoristaRepositorio
    {

        private readonly DataContext _dbcontext;
        private readonly IMapper _mapper;

        public MotoristaRepositorio(DataContext dataContext, IMapper mapper)
        {
            _dbcontext = dataContext;
            _mapper = mapper;
        }

        public async Task<MotoristaDto> BuscarPorID(Guid id)
        {
            var resultado = await _dbcontext.Motoristas.FirstOrDefaultAsync(x => x.Id == id);
            var resultadoDto = _mapper.Map<MotoristaDto>(resultado);

            return resultadoDto;
        }

        public async Task<List<MotoristaDto>> BuscarTodosMotoristas()
        {
            return await _dbcontext.Motoristas
                   .Select(x => new MotoristaDto { Id = x.Id, Nome = x.Nome, Sobrenome = x.Sobrenome, Rg = x.Rg,Cnh = x.Cnh, Contato = x.Contato, DataNascimento = x.DataNascimento, Salario = x.Salario, Imagem = x.Imagem, Onibus = x.Onibus })
                   .ToListAsync();
        }

        public async Task<MotoristaDto> Adicionar(Motorista motorista)
        {
            string nomeCompleto = motorista.GetNomeCompleto();
            Motorista motoristaBd = await _dbcontext.Motoristas.Where(x => x.NomeCompleto == nomeCompleto).FirstOrDefaultAsync();

            if (motoristaBd != null)
            {
                throw new Exception($"Motorista com nome  {nomeCompleto} já esta cadastrado!");
            }
            motorista.Id = new Guid();
            motorista.NomeCompleto = nomeCompleto;

            await _dbcontext.Motoristas.AddAsync(motorista);
            await _dbcontext.SaveChangesAsync();

            var resultadoDto = _mapper.Map<MotoristaDto>(motorista);
            return resultadoDto;
        }

        public async Task<MotoristaDto> Atualizar(Guid id, Motorista motorista)
        {
            Motorista? motoristaBd = await _dbcontext.Motoristas.FirstOrDefaultAsync(x => x.Id == id);

            if (motoristaBd == null)
            {
                throw new Exception($"Usuario com Id: {id} não encontrado!");
            }

            motoristaBd.Nome = motorista.Nome;
            motoristaBd.Sobrenome = motorista.Sobrenome;
            motoristaBd.Rg = motorista.Rg;
            motoristaBd.DataNascimento = motorista.DataNascimento;
            motoristaBd.Contato = motorista.Contato;
            motoristaBd.Cnh = motorista.Cnh;
            motoristaBd.Salario = motorista.Salario;
            motoristaBd.Imagem = motorista.Imagem;
            motoristaBd.NomeCompleto = motorista.GetNomeCompleto();

            _dbcontext.Motoristas.Update(motoristaBd);
            await _dbcontext.SaveChangesAsync();

            var resultadoDto = _mapper.Map<MotoristaDto>(motoristaBd);
            return resultadoDto;
        }

        public async Task<Boolean> Deletar(Guid id)
        {
            Motorista? motoristaBd = await _dbcontext.Motoristas.FirstOrDefaultAsync(x => x.Id == id);

            if (motoristaBd == null)
            {
                throw new Exception($"Usuario com Id: {id} não encontrado!");
            }
            _dbcontext.Motoristas.Remove(motoristaBd);
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
