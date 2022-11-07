using Microsoft.AspNetCore.Mvc;
using ProjetoMinsait.Models;
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
        public async Task<ActionResult<List<Onibus>>> BuscarTodosOnibuss()
        {
            List<Onibus> resultado = await _onibusRepositorio.BuscarTodosOnibus();
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Onibus>> BuscarPorID(Guid id)
        {
            Onibus resultado = await _onibusRepositorio.BuscarPorID(id);
            return resultado == null ? BadRequest() : Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<Onibus>> Cadastrar([FromBody] Onibus onibus) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Onibus resultado = await _onibusRepositorio.Adicionar(onibus);
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
            Onibus resultado = await _onibusRepositorio.Atualizar(id, onibus);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Deletar(Guid id)
        {
            bool resultado = await _onibusRepositorio.Deletar(id);
            return Ok(resultado);
        }

    }
}
