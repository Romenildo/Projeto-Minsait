using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetoMinsait.Data;
using ProjetoMinsait.Models;
using ProjetoMinsait.Models.Dtos;
using ProjetoMinsait.Repository.Interfaces;

namespace ProjetoMinsait.Repository
{
    public class OnibusRepositorio : IOnibusRepositorio
    {

        private readonly DataContext _dbcontext;
        private readonly IMapper _mapper;

        public OnibusRepositorio(DataContext dataContext, IMapper mapper)
        {
            _dbcontext = dataContext;
            _mapper = mapper;
        }

        public async Task<OnibusDto> BuscarPorID(Guid id)
        {
            var resultado = await _dbcontext.Onibus.FirstOrDefaultAsync(x => x.Id == id);
            var resultadoDto = _mapper.Map<OnibusDto>(resultado);
            return resultadoDto;
        }
        
        public async Task<List<OnibusDto>> BuscarTodosOnibus()
        {
            return await _dbcontext.Onibus
                   .Select(x => new OnibusDto { Id = x.Id,NomeViacao = x.NomeViacao,Cobrador = x.Cobrador, Motorista = x.Motorista, Passagem = x.Passagem })
                   .ToListAsync();
        }

        public async Task<OnibusDto> Adicionar(Onibus onibus)
        {
            onibus.Id = new Guid();
            await _dbcontext.Onibus.AddAsync(onibus);
            await _dbcontext.SaveChangesAsync();

            var resultadoDto = _mapper.Map<OnibusDto>(onibus);
            return resultadoDto;
        }

        public async Task<OnibusDto> Atualizar(Guid id, Onibus onibus)
        {
            Onibus onibusBd = await _dbcontext.Onibus.FirstOrDefaultAsync(x => x.Id == id);

            if (onibusBd == null)
            {
                throw new Exception($"Onibus com Id: {id} não encontrado!");
            }

            onibusBd.NomeViacao = onibus.NomeViacao;

            _dbcontext.Onibus.Update(onibusBd);
            await _dbcontext.SaveChangesAsync();

            var resultadoDto = _mapper.Map<OnibusDto>(onibusBd);
            return resultadoDto;
        }

        public async Task<Boolean> Deletar(Guid id)
        {
            Onibus onibusBd = await _dbcontext.Onibus.FirstOrDefaultAsync(x => x.Id == id);

            if (onibusBd == null)
            {
                throw new Exception($"Onibus com Id: {id} não encontrado!");
            }
            _dbcontext.Onibus.Remove(onibusBd);
            await _dbcontext.SaveChangesAsync();

            return true;
        }

        public async Task<string> VincularCobrador(Guid idOnibus, string nomeCobrador)
        {
            Onibus onibusBd = await _dbcontext.Onibus.Where(x => x.Id == idOnibus).FirstOrDefaultAsync();
            Cobrador cobradorBd = await _dbcontext.Cobradores.Where(x => x.NomeCompleto == nomeCobrador).FirstOrDefaultAsync();

            if (onibusBd == null )
            {
                throw new Exception($"Onibus com Id: {idOnibus} não encontrado!");
            }
            if (cobradorBd == null)
            {
                throw new Exception($"Cobrador: {nomeCobrador} não encontrado! Deve ter o formato NomeSobrenome. Ex: JoaoCarlos");
            }

            onibusBd.Cobrador = cobradorBd;
            cobradorBd.OnibusId = onibusBd.Id;
            cobradorBd.Onibus = onibusBd;

            _dbcontext.Onibus.Update(onibusBd);
            _dbcontext.Cobradores.Update(cobradorBd);

            await _dbcontext.SaveChangesAsync();

            return "Cobrador cadastrado com sucesso!";
        }

        public async Task<string> VincularMotorista(Guid idOnibus, string nomeMotorista)
        {
            Onibus onibusBd = await _dbcontext.Onibus.Where(x => x.Id == idOnibus).FirstOrDefaultAsync();
            Motorista motoristaBd = await _dbcontext.Motoristas.Where(x => x.NomeCompleto == nomeMotorista).FirstOrDefaultAsync();

            if (onibusBd == null)
            {
                throw new Exception($"Onibus com Id: {idOnibus} não encontrado!");
            }
            if (motoristaBd == null)
            {
                throw new Exception($"Motorista: {nomeMotorista} não encontrado! Deve ter o formato NomeSobrenome. Ex: JoaoCarlos");
            }

            onibusBd.Motorista = motoristaBd;
            motoristaBd.OnibusId = onibusBd.Id;
            motoristaBd.Onibus = onibusBd;

            _dbcontext.Onibus.Update(onibusBd);
            _dbcontext.Motoristas.Update(motoristaBd);

            await _dbcontext.SaveChangesAsync();

            return "Motorista cadastrado com sucesso!";
        }

        public async Task<string> VincularPassagem(Guid idOnibus, Guid idPassagem)
        {
            Onibus onibusBd = await _dbcontext.Onibus.Where(x => x.Id == idOnibus).FirstOrDefaultAsync();
            Passagem passagemBd = await _dbcontext.Passagem.Where(x => x.Id == idPassagem).FirstOrDefaultAsync();

            if (onibusBd == null)
            {
                throw new Exception($"Onibus com Id: {idOnibus} não encontrado!");
            }
            if (passagemBd == null)
            {
                throw new Exception($"Passagem com Id: {idPassagem} não encontrado!");
            }

            onibusBd.Passagem = passagemBd;
            passagemBd.OnibusId = onibusBd.Id;
            passagemBd.Onibus = onibusBd;

            _dbcontext.Onibus.Update(onibusBd);
            _dbcontext.Passagem.Update(passagemBd);

            await _dbcontext.SaveChangesAsync();

            return "Passagem cadastrada com sucesso!";
        }
    }
}
