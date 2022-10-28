﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<Onibus> BuscarPorID(int id)
        {
            return await _dbcontext.Onibus.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<List<Onibus>> BuscarTodosOnibus()
        {
            return await _dbcontext.Onibus.ToListAsync();

        }

        public async Task<Onibus> Adicionar(Onibus onibus)
        {
            await _dbcontext.Onibus.AddAsync(onibus);
            await _dbcontext.SaveChangesAsync();
            return onibus;
        }

        public async Task<Onibus> Atualizar(int id, Onibus onibus)
        {
            Onibus onibusBd = await BuscarPorID(id);

            if (onibusBd == null)
            {
                throw new Exception($"Usuario com Id: ${id} não encontrado!");
            }

            

            _dbcontext.Onibus.Update(onibusBd);
            await _dbcontext.SaveChangesAsync();
            return onibusBd;

        }

        public async Task<bool> Deletar(int id)
        {
            Onibus onibusBd = await BuscarPorID(id);

            if (onibusBd == null)
            {
                throw new Exception($"Usuario com Id: ${id} não encontrado!");
            }
            _dbcontext.Onibus.Remove(onibusBd);
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
