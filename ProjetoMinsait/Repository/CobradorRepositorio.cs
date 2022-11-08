using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetoMinsait.Data;
using ProjetoMinsait.Models;
using ProjetoMinsait.Models.Dtos;
using ProjetoMinsait.Repository.Interfaces;

namespace ProjetoMinsait.Repository
{
    public class CobradorRepositorio : ICobradorRepositorio
    {

        private readonly DataContext _dbcontext;
        private readonly IMapper _mapper;

        public CobradorRepositorio(DataContext dataContext, IMapper mapper)
        {
            _dbcontext = dataContext;
            _mapper = mapper;
        }

        public async Task<CobradorDto> BuscarPorID(Guid id)
        {
            var resultado = await _dbcontext.Cobradores.FirstOrDefaultAsync(x => x.Id == id);
            var resultadoDto = _mapper.Map<CobradorDto>(resultado);

            return resultadoDto;
        }

        public async Task<List<CobradorDto>> BuscarTodosCobradores()
        {
            return await _dbcontext.Cobradores
                   .Select(x => new CobradorDto { Id = x.Id, Nome = x.Nome, Sobrenome = x.Sobrenome, Rg = x.Rg,Contato = x.Contato,DataNascimento = x.DataNascimento, Salario = x.Salario })
                   .ToListAsync();

        }

        public async Task<CobradorDto> Adicionar(Cobrador cobrador)
        {
            cobrador.Id = new Guid();
            cobrador.Onibus = null;

            await _dbcontext.Cobradores.AddAsync(cobrador);
            await _dbcontext.SaveChangesAsync();

            var resultadoDto = _mapper.Map<CobradorDto>(cobrador);
            return resultadoDto;
        }

        public async Task<CobradorDto> Atualizar(Guid id, Cobrador cobrador)
        {
            Cobrador cobradorBd = await _dbcontext.Cobradores.FirstOrDefaultAsync(x => x.Id == id);

            if (cobradorBd == null)
            {
                throw new Exception($"Usuario com Id: {id} não encontrado!");
            }

            cobradorBd.Nome = cobrador.Nome;
            cobradorBd.Rg = cobrador.Rg;
            cobradorBd.DataNascimento = cobrador.DataNascimento;
            cobradorBd.Contato = cobrador.Contato;
            cobradorBd.Salario = cobrador.Salario;

            _dbcontext.Cobradores.Update(cobradorBd);
            await _dbcontext.SaveChangesAsync();

            var resultadoDto = _mapper.Map<CobradorDto>(cobradorBd);
            return resultadoDto;

        }

        public async Task<string> Deletar(Guid id)
        {
            Cobrador cobradorBd = await _dbcontext.Cobradores.FirstOrDefaultAsync(x => x.Id == id);

            if (cobradorBd == null)
            {
                throw new Exception($"Usuario com Id: {id} não encontrado!");
            }
            _dbcontext.Cobradores.Remove(cobradorBd);
            await _dbcontext.SaveChangesAsync();

            return "Cobrador deletado com sucesso!";
        }
    }
}
