using Microsoft.EntityFrameworkCore;
using ProjetoMinsait.Data;
using ProjetoMinsait.Models;
using ProjetoMinsait.Repository.Interfaces;

namespace ProjetoMinsait.Repository
{
    public class OnibusRepositorio : IOnibusRepositorio
    {

        private readonly DataContext _dbcontext;

        public OnibusRepositorio(DataContext dataContext) 
        { 
            _dbcontext = dataContext;
        }

        public async Task<Onibus> BuscarPorID(Guid id)
        {
            return await _dbcontext.Onibus
                .Where(x => x.Id == id)
                .Include(x => x.Motorista)
                .FirstOrDefaultAsync();
        }
        
        public async Task<List<Onibus>> BuscarTodosOnibus()
        {
            //return await _dbcontext.Onibus.ToListAsync();
            return await _dbcontext.Onibus.Include(x=>x.Motorista).ToListAsync();

        }

        public async Task<Onibus> Adicionar(Onibus onibus)
        {
            onibus.Id = new Guid();
            await _dbcontext.Onibus.AddAsync(onibus);
            await _dbcontext.SaveChangesAsync();
            return onibus;
        }

        public async Task<Onibus> Atualizar(Guid id, Onibus onibus)
        {
            Onibus onibusBd = await BuscarPorID(id);

            if (onibusBd == null)
            {
                throw new Exception($"Usuario com Id: {id} não encontrado!");
            }

            

            _dbcontext.Onibus.Update(onibusBd);
            await _dbcontext.SaveChangesAsync();
            return onibusBd;

        }

        public async Task<bool> Deletar(Guid id)
        {
            Onibus onibusBd = await BuscarPorID(id);

            if (onibusBd == null)
            {
                throw new Exception($"Usuario com Id: {id} não encontrado!");
            }
            _dbcontext.Onibus.Remove(onibusBd);
            await _dbcontext.SaveChangesAsync();

            return true;
        }
        //Relacionamentos
        public async Task<string> VincularCobrador(Guid idOnibus, string nomeCobrador)
        {
            Onibus onibusBd = await _dbcontext.Onibus.Where(x => x.Id == idOnibus).FirstOrDefaultAsync();
            Cobrador cobradorBd = await _dbcontext.Cobradores.Where(x => x.Nome == nomeCobrador).FirstOrDefaultAsync();

            if (onibusBd == null )
            {
                throw new Exception($"Cobrador: {nomeCobrador} não encontrado!");
            }
            if (cobradorBd == null)
            {
                throw new Exception($"Onibus com Id: {idOnibus} não encontrado!");
            }

            onibusBd.Cobrador = cobradorBd;
            cobradorBd.OnibusId = onibusBd.Id;
            cobradorBd.Onibus = onibusBd;

            await _dbcontext.Onibus.AddAsync(onibusBd);
            await _dbcontext.Cobradores.AddAsync(cobradorBd);

            await _dbcontext.SaveChangesAsync();

            return "Cobrador cadastrado com sucesso";
        }
    }
}
