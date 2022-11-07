using Microsoft.AspNetCore.Mvc;
using ProjetoMinsait.Models;
using ProjetoMinsait.Repository.Interfaces;

namespace ProjetoMinsait.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class PassagemController : ControllerBase
    {

        private readonly IPassagemRepositorio _passagemRepositorio;

        public PassagemController(IPassagemRepositorio passagemRepositorio)
        {
            _passagemRepositorio = passagemRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Passagem>>> BuscarTodosPassagems()
        {
            List<Passagem> resultado = await _passagemRepositorio.BuscarTodasPassagens();
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Passagem>> BuscarPorID(Guid id)
        {
            Passagem resultado = await _passagemRepositorio.BuscarPorID(id);
            return resultado == null ? BadRequest() : Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<Passagem>> Cadastrar([FromBody] Passagem passagem) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Passagem resultado = await _passagemRepositorio.Adicionar(passagem);
            return Created($"v1/api/passagem/{resultado.Id}", resultado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Passagem>> Atualizar(Guid id, [FromBody] Passagem passagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            passagem.Id = id;
            Passagem resultado = await _passagemRepositorio.Atualizar(id, passagem);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Deletar(Guid id)
        {
            bool resultado = await _passagemRepositorio.Deletar(id);
            return Ok(resultado);
        }

    }
}
