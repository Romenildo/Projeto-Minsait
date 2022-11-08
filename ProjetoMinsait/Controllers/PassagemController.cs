using Microsoft.AspNetCore.Mvc;
using ProjetoMinsait.Models;
using ProjetoMinsait.Models.Dtos;
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
        public async Task<ActionResult<List<PassagemDto>>> BuscarTodosPassagems()
        {
            List<PassagemDto> resultado = await _passagemRepositorio.BuscarTodasPassagens();
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PassagemDto>> BuscarPorID(Guid id)
        {
            PassagemDto resultado = await _passagemRepositorio.BuscarPorID(id);
            return resultado == null ? BadRequest() : Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<PassagemDto>> Cadastrar([FromBody] Passagem passagem) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            PassagemDto resultado = await _passagemRepositorio.Adicionar(passagem);
            return Created($"v1/api/passagem/{resultado.Id}", resultado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PassagemDto>> Atualizar(Guid id, [FromBody] Passagem passagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            passagem.Id = id;
            PassagemDto resultado = await _passagemRepositorio.Atualizar(id, passagem);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Deletar(Guid id)
        {
            string resultado = await _passagemRepositorio.Deletar(id);
            return Ok(resultado);
        }

    }
}
