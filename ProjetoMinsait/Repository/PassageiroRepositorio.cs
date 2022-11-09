using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetoMinsait.Data;
using ProjetoMinsait.Models;
using ProjetoMinsait.Models.Dtos;
using ProjetoMinsait.Repository.Interfaces;

namespace ProjetoMinsait.Repository
{
    public class PassageiroRepositorio : IPassageiroRepositorio
    {

        private readonly DataContext _dbcontext;
        private readonly IMapper _mapper;

        public PassageiroRepositorio(DataContext dataContext, IMapper mapper) 
        { 
            _dbcontext = dataContext;
            _mapper = mapper;
        }

        public async Task<PassageiroDto> BuscarPorID(Guid id)
        {
            var resultado = await _dbcontext.Passageiros.FirstOrDefaultAsync(x => x.Id == id);
            var resultadoDto = _mapper.Map<PassageiroDto>(resultado);
            return resultadoDto;

        }

        public async Task<List<PassageiroDto>> BuscarTodosPassageiros()
        {
            return await _dbcontext.Passageiros
                   .Select(x => new PassageiroDto { Id = x.Id, Nome = x.Nome, Sobrenome = x.Sobrenome, Rg = x.Rg, Email = x.Email, Contato = x.Contato, DataNascimento = x.DataNascimento, Assento = x.Assento, Seguro = x.Seguro, Passagem = x.Passagem})
                   .ToListAsync();
        }

        public async Task<PassageiroDto> Adicionar(Passageiro passageiro)
        {
            passageiro.Id = new Guid();
            passageiro.NomeCompleto = passageiro.GetNomeCompleto();

            await _dbcontext.Passageiros.AddAsync(passageiro);
            await _dbcontext.SaveChangesAsync();
            var resultadoDto = _mapper.Map<PassageiroDto>(passageiro);

            return resultadoDto;
        }

        public async Task<PassageiroDto> Atualizar(Guid id, Passageiro passageiro)
        {
            Passageiro passageiroBd = await _dbcontext.Passageiros.FirstOrDefaultAsync(x => x.Id == id);

            if (passageiroBd == null)
            {
                throw new Exception($"Usuario com Id: {id} não encontrado!");
            }

            passageiroBd.Nome = passageiro.Nome;
            passageiroBd.Rg = passageiro.Rg;
            passageiroBd.DataNascimento = passageiro.DataNascimento;
            passageiroBd.Contato = passageiro.Contato;
            passageiroBd.Email = passageiro.Email;
            passageiroBd.Seguro = passageiro.Seguro;
            passageiro.NomeCompleto = passageiro.GetNomeCompleto();

            _dbcontext.Passageiros.Update(passageiroBd);
            await _dbcontext.SaveChangesAsync();

            var resultadoDto = _mapper.Map<PassageiroDto>(passageiroBd);
            return resultadoDto;

        }

        public async Task<string> Deletar(Guid id)
        {
            Passageiro passageiroBd = await _dbcontext.Passageiros.FirstOrDefaultAsync(x => x.Id == id);

            if (passageiroBd == null)
            {
                throw new Exception($"Usuario com Id: {id} não encontrado!");
            }
            _dbcontext.Passageiros.Remove(passageiroBd);
            await _dbcontext.SaveChangesAsync();

            return "Passageiro deletado com sucesso!";
        }
        public async Task<string> ComprarPassagem(string nomePassageiro, Guid idPassagem)
        {
            Passagem passagemBd = await _dbcontext.Passagem.Where(x => x.Id == idPassagem).FirstOrDefaultAsync();
            Passageiro passageiroBd = await _dbcontext.Passageiros.Where(x => x.NomeCompleto == nomePassageiro).FirstOrDefaultAsync();

            if (passageiroBd == null)
            {
                throw new Exception($"Passageiro: { nomePassageiro } não encontrado!");
            }
            if (passagemBd == null)
            {
                throw new Exception($"Passagem com Id: { passagemBd } não encontrado!");
            }

            passageiroBd.Passagem = passagemBd;
            passagemBd.Passageiros?.Add(passageiroBd);

            passageiroBd.ValorPassagem = passageiroBd.CalcularValorPassagem(passagemBd.PrecoPassagem);

             _dbcontext.Passageiros.Update(passageiroBd);
            _dbcontext.Passagem.Update(passagemBd);

            await _dbcontext.SaveChangesAsync();

            return "Passagem cadastrada com sucesso";
        }
        public async Task<string> CancelarPassagem(string nomePassageiro, Guid idPassagem)
        {
            Passagem passagemBd = await _dbcontext.Passagem.Where(x => x.Id == idPassagem).FirstOrDefaultAsync();
            Passageiro passageiroBd = await _dbcontext.Passageiros.Where(x => x.NomeCompleto == nomePassageiro).FirstOrDefaultAsync();

            if (passageiroBd == null)
            {
                throw new Exception($"Passageiro: {nomePassageiro} não encontrado!");
            }
            if (passagemBd == null)
            {
                throw new Exception($"Passagem com Id: {passagemBd} não encontrado!");
            }
            passagemBd.Passageiros?.Remove(passageiroBd);
            passageiroBd.Passagem = null;
            passageiroBd.ValorPassagem = 0.0;

            _dbcontext.Passageiros.Update(passageiroBd);
            _dbcontext.Passagem.Update(passagemBd);

            await _dbcontext.SaveChangesAsync();

            return "Passagem cancelada com sucesso";
        }
    }
}
