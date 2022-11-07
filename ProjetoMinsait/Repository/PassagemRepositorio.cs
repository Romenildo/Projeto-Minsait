using Microsoft.EntityFrameworkCore;
using ProjetoMinsait.Data;
using ProjetoMinsait.Models;
using ProjetoMinsait.Repository.Interfaces;

namespace ProjetoMinsait.Repository
{
    public class PassagemRepositorio : IPassagemRepositorio
    {

        private readonly DataContext _dbcontext;

        public PassagemRepositorio(DataContext dataContext) 
        { 
            _dbcontext = dataContext;
        }

        public async Task<Passagem> BuscarPorID(Guid id)
        {
            return await _dbcontext.Passagem.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Passagem>> BuscarTodasPassagens()
        {
            return await _dbcontext.Passagem.AsNoTracking().ToListAsync();

        }

        public async Task<Passagem> Adicionar(Passagem passagem)
        {
            await _dbcontext.Passagem.AddAsync(passagem);
            await _dbcontext.SaveChangesAsync();
            return passagem;
        }

        public async Task<Passagem> Atualizar(Guid id, Passagem Passagem)
        {
            Passagem passagemBd = await BuscarPorID(id);

            if (passagemBd == null)
            {
                throw new Exception($"Usuario com Id: ${id} não encontrado!");
            }

            _dbcontext.Passagem.Update(passagemBd);
            await _dbcontext.SaveChangesAsync();
            return passagemBd;

        }

        public async Task<bool> Deletar(Guid id)
        {
            Passagem passagemBd = await BuscarPorID(id);

            if (passagemBd == null)
            {
                throw new Exception($"Usuario com Id: ${id} não encontrado!");
            }
            _dbcontext.Passagem.Remove(passagemBd);
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
