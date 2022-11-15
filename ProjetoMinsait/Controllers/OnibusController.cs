using Microsoft.AspNetCore.Mvc;
using ProjetoMinsait.Models;
using ProjetoMinsait.Models.Dtos;
using ProjetoMinsait.Repository.Interfaces;

namespace ProjetoMinsait.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class OnibusController : ControllerBase
    {
        private readonly IOnibusRepositorio _onibusRepositorio;

        public OnibusController(IOnibusRepositorio onibusRepositorio)
        {
            _onibusRepositorio = onibusRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<OnibusDto>>> BuscarTodosOnibuss()
        {
            List<OnibusDto> resultado = await _onibusRepositorio.BuscarTodosOnibus();
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OnibusDto>> BuscarPorID(Guid id)
        {
            OnibusDto resultado = await _onibusRepositorio.BuscarPorID(id);
            return resultado == null ? BadRequest() : Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<OnibusDto>> Cadastrar([FromBody] Onibus onibus) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            OnibusDto resultado = await _onibusRepositorio.Adicionar(onibus);
            return Created($"v1/api/onibus/{resultado.Id}", resultado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Onibus>> Atualizar(Guid id, [FromBody] Onibus onibus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            onibus.Id = id;
            OnibusDto resultado = await _onibusRepositorio.Atualizar(id, onibus);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Boolean>> Deletar(Guid id)
        {
            Boolean resultado = await _onibusRepositorio.Deletar(id);
            return Ok(resultado);
        }
        
        [HttpPut("{idOnibus}/vincularCobrador/{nomeCobrador}")]
        public async Task<ActionResult<string>> VicnularCobrador(Guid idOnibus, string nomeCobrador)
        {
            string resultado = await _onibusRepositorio.VincularCobrador(idOnibus, nomeCobrador);
            return Ok(resultado);
        }

        [HttpPut("{idOnibus}/vincularMotorista/{nomeSobrenome}")]
        public async Task<ActionResult<string>> VicnularMotorista(Guid idOnibus, string nomeSobrenome)
        {
            string resultado = await _onibusRepositorio.VincularMotorista(idOnibus, nomeSobrenome);
            return Ok(resultado);
        }

        [HttpPut("{idOnibus}/vincularPassagem/{idPassagem}")]
        public async Task<ActionResult<string>> VicnularPassagem(Guid idOnibus, Guid idPassagem)
        {
            string resultado = await _onibusRepositorio.VincularPassagem(idOnibus, idPassagem);
            return Ok(resultado);
        }
    }
}
