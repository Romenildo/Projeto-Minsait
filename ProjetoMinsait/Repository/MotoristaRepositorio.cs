using Microsoft.EntityFrameworkCore;
using ProjetoMinsait.Data;
using ProjetoMinsait.Models;
using ProjetoMinsait.Repository.Interfaces;

namespace ProjetoMinsait.Repository
{
    public class MotoristaRepositorio : IMotoristaRepositorio
    {

        private readonly DataContext _dbcontext;

        public MotoristaRepositorio(DataContext dataContext) 
        { 
            _dbcontext = dataContext;
        }

        public async Task<Motorista> BuscarPorID(Guid id)
        {
            return await _dbcontext.Motoristas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Motorista>> BuscarTodosMotoristas()
        {
            return await _dbcontext.Motoristas.ToListAsync();

        }

        public async Task<Motorista> Adicionar(Motorista motorista)
        {
            await _dbcontext.Motoristas.AddAsync(motorista);
            await _dbcontext.SaveChangesAsync();
            return motorista;
        }

        public async Task<Motorista> Atualizar(Guid id, Motorista motorista)
        {
            Motorista motoristaBd = await BuscarPorID(id);

            if (motoristaBd == null)
            {
                throw new Exception($"Usuario com Id: {id} não encontrado!");
            }

            motoristaBd.Nome = motorista.Nome;
            motoristaBd.Rg = motorista.Rg;
            motoristaBd.DataNascimento = motorista.DataNascimento;
            motoristaBd.Contato = motorista.Contato;
            motoristaBd.Cnh = motorista.Cnh;
            motoristaBd.Salario = motorista.Salario;

            _dbcontext.Motoristas.Update(motoristaBd);
            await _dbcontext.SaveChangesAsync();
            return motoristaBd;

        }

        public async Task<bool> Deletar(Guid id)
        {
            Motorista motoristaBd = await BuscarPorID(id);

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
