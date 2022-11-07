using Microsoft.EntityFrameworkCore;
using ProjetoMinsait.Data;
using ProjetoMinsait.Models;
using ProjetoMinsait.Repository.Interfaces;

namespace ProjetoMinsait.Repository
{
    public class PassageiroRepositorio : IPassageiroRepositorio
    {

        private readonly DataContext _dbcontext;

        public PassageiroRepositorio(DataContext dataContext) 
        { 
            _dbcontext = dataContext;
        }

        public async Task<Passageiro> BuscarPorID(Guid id)
        {
            return await _dbcontext.Passageiros.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Passageiro>> BuscarTodosPassageiros()
        {
            return await _dbcontext.Passageiros.AsNoTracking().ToListAsync();

        }

        public async Task<Passageiro> Adicionar(Passageiro passageiro)
        {
            await _dbcontext.Passageiros.AddAsync(passageiro);
            await _dbcontext.SaveChangesAsync();
            return passageiro;
        }

        public async Task<Passageiro> Atualizar(Guid id, Passageiro passageiro)
        {
            Passageiro passageiroBd = await BuscarPorID(id);

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

            _dbcontext.Passageiros.Update(passageiroBd);
            await _dbcontext.SaveChangesAsync();
            return passageiroBd;

        }

        public async Task<bool> Deletar(Guid id)
        {
            Passageiro passageiroBd = await BuscarPorID(id);

            if (passageiroBd == null)
            {
                throw new Exception($"Usuario com Id: {id} não encontrado!");
            }
            _dbcontext.Passageiros.Remove(passageiroBd);
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
