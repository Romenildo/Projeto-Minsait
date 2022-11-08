using Microsoft.EntityFrameworkCore;
using ProjetoMinsait.Data;
using ProjetoMinsait.Models;
using ProjetoMinsait.Repository.Interfaces;

namespace ProjetoMinsait.Repository
{
    public class CobradorRepositorio : ICobradorRepositorio
    {

        private readonly DataContext _dbcontext;

        public CobradorRepositorio(DataContext dataContext) 
        { 
            _dbcontext = dataContext;
        }

        public async Task<Cobrador> BuscarPorID(Guid id)
        {
            return await _dbcontext.Cobradores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Cobrador>> BuscarTodosCobradores()
        {
            return await _dbcontext.Cobradores.ToListAsync();

        }

        public async Task<Cobrador> Adicionar(Cobrador cobrador)
        {
            cobrador.Id = new Guid();
            cobrador.Onibus = null;

            await _dbcontext.Cobradores.AddAsync(cobrador);
            await _dbcontext.SaveChangesAsync();
            return cobrador;
        }

        public async Task<Cobrador> Atualizar(Guid id, Cobrador cobrador)
        {
            Cobrador cobradorBd = await BuscarPorID(id);

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
            return cobradorBd;

        }

        public async Task<bool> Deletar(Guid id)
        {
            Cobrador cobradorBd = await BuscarPorID(id);

            if (cobradorBd == null)
            {
                throw new Exception($"Usuario com Id: {id} não encontrado!");
            }
            _dbcontext.Cobradores.Remove(cobradorBd);
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
